using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Web;
using Azure.Core;
using BudgetBuddy.Domain.Dtos.Requests;
using BudgetBuddy.Domain.Dtos.Response;
using BudgetBuddy.Domain.Dtos.Usuarios;
using BudgetBuddy.Domain.Entities.Jwt;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace BudgetBuddy.Service.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<IdentityUser > _signInManager;
    private readonly UserManager<IdentityUser > _userManager;
    private readonly JwtSettings _jwtSettings;

    public IdentityService(SignInManager<IdentityUser > signInManager,
                            UserManager<IdentityUser > userManager,
                            IOptions<JwtSettings> jwtSettings)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<UsuarioCadastroResponse> CadstrarUsuario(UsuarioCadastroRequest usuarioCadastroRequest)
    {
        var identityUser = new IdentityUser 
        {
            UserName = usuarioCadastroRequest.Email,
            Email = usuarioCadastroRequest.Email,
            EmailConfirmed = false
        };
        
        var result = await _userManager.CreateAsync(identityUser, usuarioCadastroRequest.Senha);
        if (result.Succeeded)
        {
            await _userManager.SetLockoutEnabledAsync(identityUser, false);
        }

        var usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);

        if (!result.Succeeded && result.Errors.Count() > 0)
        {
            usuarioCadastroResponse.AdicionarErro(result.Errors.Select(x => x.Description));
        }
        
        return usuarioCadastroResponse;
    }

    public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLoginRequest)
    {
        var result = await _signInManager.PasswordSignInAsync(usuarioLoginRequest.Email, usuarioLoginRequest.Senha, false, true);

        if (result.Succeeded)
            return await GerarCredenciais(usuarioLoginRequest.Email);
        
        var usuarioLoginResponse = new UsuarioLoginResponse();
        if (!result.Succeeded)
        {
            if(result.IsLockedOut)
                usuarioLoginResponse.AdicionarErro("Esta conta está bloqueada!");
            else if(result.IsNotAllowed)
                usuarioLoginResponse.AdicionarErro("Esta conta não tem permissão para fazer login!");
            
            else if(result.RequiresTwoFactor)
                usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu Email");
            else 
                usuarioLoginResponse.AdicionarErro("Usuário ou senha incorretos!");

        }
        
        return usuarioLoginResponse;
    }

    public async Task<UsuarioLoginResponse> LoginSemSenha(string usuarioId)
    {
        var usuarioLoginResponse = new UsuarioLoginResponse();
        var usuario = await _userManager.FindByIdAsync(usuarioId);

        if (await _userManager.IsLockedOutAsync(usuario))
            usuarioLoginResponse.AdicionarErro("Esta conta está bloqueada");
        if (!await _userManager.IsEmailConfirmedAsync(usuario))
            usuarioLoginResponse.AdicionarErro("Esta conta precisa confirmar o email antes do login");

        if (usuarioLoginResponse.Sucesso)
            return await GerarCredenciais(usuario.Email);
        
        return usuarioLoginResponse;
    }

    public async Task<UsuarioVerifyResponse> VerificarEmail(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var response = new UsuarioVerifyResponse
        {
            EmailCadastrado = email
        };
        
        response.Ativo = user is not null;
        
        return response; 
    }

    private async Task<UsuarioLoginResponse> GerarCredenciais(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var acessTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: true);
        var refreshTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: false);

        var dataExpiracaoAcessToken = DateTime.Now.AddSeconds(_jwtSettings.AccesTokenExpiration);
        var dataExpiracaoRefreshToken = DateTime.Now.AddSeconds(_jwtSettings.RefreshTokenExpiration);

        var accessToken = GerarToken(acessTokenClaims, dataExpiracaoAcessToken);
        var refreshToken = GerarToken(refreshTokenClaims, dataExpiracaoRefreshToken);

        return new UsuarioLoginResponse(
            sucesso: true,
            accessToken: accessToken,
            refreshToken: refreshToken
        );
    }
    

    private string GerarToken(IEnumerable<Claim> claims, DateTime dataExpiracao)
    {   
        var jwt = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            notBefore: dataExpiracao,
            expires: dataExpiracao,
            signingCredentials: _jwtSettings.SigningCredentials);
        
        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }

    private async Task<IList<Claim>> ObterClaims(IdentityUser  user, bool adicionarClaimsUsuario)
    {
        var claims = new List<Claim>();
        
        claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
        claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
        claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, DateTime.Now.ToString()));
        claims.Add(new Claim(JwtRegisteredClaimNames.Iat, DateTime.Now.ToString()));

        if (adicionarClaimsUsuario)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            
            claims.AddRange(userClaims);
            
            foreach (var role in roles)
            {
                claims.Add(new Claim("role", role));
            }
        }
        
        return claims;
    }


    // public async Task<UsuarioCadastroResponse> CadastrarUsuarioInicial(UsuarioCadastroInicialRequest request)
    // {
    //     var identityUser = new IdentityUser 
    //     {
    //         UserName = request.Nome,
    //         Email = request.Email,
    //         EmailConfirmed = false, // A conta ainda não está ativa 
    //         Cpf = request.Cpf,
    //         DataNascimento = request.DataNascimento
    //     };
    //
    //     var result = await _userManager.CreateAsync(identityUser);
    //
    //     if (!result.Succeeded)
    //     {
    //         return new UsuarioCadastroResponse(false, result.Errors.Select(e => e.Description));
    //     }
    //
    //     // Gerar token para o usuário definir a senha
    //     var token = await _userManager.GeneratePasswordResetTokenAsync(identityUser);
    //
    //     // Enviar e-mail com link para definir senha (Front-end deve ter um formulário para isso)
    //     var link = $"https://seuapp.com/definir-senha?token={HttpUtility.UrlEncode(token)}&email={identityUser.Email}";
    //     await _emailService.EnviarEmailAsync(identityUser.Email, "Defina sua senha",
    //         $"Clique aqui para definir sua senha: {link}");
    //
    //     return new UsuarioCadastroResponse(true);
    // }

}