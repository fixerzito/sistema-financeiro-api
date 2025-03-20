using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using BudgetBuddy.Application.DTO.Login;
using BudgetBuddy.Domain.Dtos.Requests;
using BudgetBuddy.Domain.Dtos.Response;
using BudgetBuddy.Domain.Dtos.Usuarios;
using BudgetBuddy.Domain.Entities.Jwt;
using BudgetBuddy.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BudgetBuddy.Service.Services.Identity;

public class IdentityService : IIdentityService
{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IEmailService _emailService;
    private readonly JwtSettings _jwtSettings;

    public IdentityService(SignInManager<IdentityUser > signInManager,
                            UserManager<IdentityUser > userManager,
                            IOptions<JwtSettings> jwtSettings,
                            IEmailService emailService)
    {
        _signInManager = signInManager;
        _userManager = userManager;
        _emailService = emailService;
        _jwtSettings = jwtSettings.Value;
    }

    public async Task<UsuarioCadastroResponse> CadastroInicialAsync(UsuarioCadastroRequest usuarioCadastroRequest)
    {
        var identityUser = new IdentityUser 
        {
            UserName = usuarioCadastroRequest.Email,
            Email = usuarioCadastroRequest.Email,
            EmailConfirmed = false
        };
        
        var result = await _userManager.CreateAsync(identityUser);
        
        if (result.Succeeded)
        {
            await _userManager.SetLockoutEnabledAsync(identityUser, false);
        }
        
        var usuarioCadastroResponse = new UsuarioCadastroResponse(result.Succeeded);
        
        if (!result.Succeeded)
        {
            usuarioCadastroResponse.AdicionarErro(result.Errors.Select(x => x.Description));
            return usuarioCadastroResponse;
        }

        if (!result.Succeeded && result.Errors.Count() > 0)
        {
            usuarioCadastroResponse.AdicionarErro(result.Errors.Select(x => x.Description));
            return usuarioCadastroResponse;
        }
        
        var token = WebUtility.UrlEncode(await _userManager.GenerateEmailConfirmationTokenAsync(identityUser));
        
        await _emailService.EnviarEmailConfirmacaoAsync(identityUser.Email, token);
        
        return usuarioCadastroResponse;
    }

    public async Task<UsuarioLoginResponse> Login(UsuarioLoginRequest usuarioLoginRequest)
    {
        var usuarioLoginResponse = new UsuarioLoginResponse();
    
        var user = await _userManager.FindByEmailAsync(usuarioLoginRequest.Email);
        if (user == null)
        {
            usuarioLoginResponse.AdicionarErro("Usuário não encontrado!");
            return usuarioLoginResponse;
        }
    
        if (await _userManager.IsLockedOutAsync(user))
        {
            usuarioLoginResponse.AdicionarErro("Esta conta está bloqueada!");
            return usuarioLoginResponse;
        }
    
        if (!await _userManager.IsEmailConfirmedAsync(user))
        {
            usuarioLoginResponse.AdicionarErro("É necessário confirmar o email antes de fazer login.");
            return usuarioLoginResponse;
        }
    
        if (!await _userManager.CheckPasswordAsync(user, usuarioLoginRequest.Senha))
        {
            usuarioLoginResponse.AdicionarErro("Senha fudeuu!");
            return usuarioLoginResponse;
        }
    
        var result = await _signInManager.PasswordSignInAsync(user, usuarioLoginRequest.Senha, false, true);
    
        if (result.IsNotAllowed)
            usuarioLoginResponse.AdicionarErro("Esta conta não tem permissão para fazer login!");
        else if (result.RequiresTwoFactor)
            usuarioLoginResponse.AdicionarErro("É necessário confirmar o login no seu Email");
        else
            usuarioLoginResponse.AdicionarErro("Usuário ou senha incorretos!");
        
        if (result.Succeeded)
            return await GerarCredenciais(usuarioLoginRequest.Email);
    
        return usuarioLoginResponse;
    }
    
    public async Task<bool> ConfirmarEmailAsync(string token, string email)
    {
        var usuario = await _userManager.FindByEmailAsync(email);

        if (usuario == null)
        {
            Console.WriteLine($"Erro: Usuário com e-mail {email} não encontrado.");
            return false;
        }

        var resultado = await _userManager.ConfirmEmailAsync(usuario, token);

        if (!resultado.Succeeded)
        {
            Console.WriteLine($"Erro ao confirmar e-mail: {string.Join(", ", resultado.Errors.Select(e => e.Description))}");
            return false;
        }

        Console.WriteLine($"Sucesso: E-mail {email} confirmado.");
        return true;
    }

    
    public async Task<bool> CadastrarSenhaAsync(CadastroSenhaRequest request)
    {
        var usuario = await _userManager.FindByEmailAsync(request.Email);

        if (usuario == null)
            return false;

        if (!usuario.EmailConfirmed)
            return false;

        var resultado = await _userManager.AddPasswordAsync(usuario, request.Senha);

        if (!resultado.Succeeded)
        {
            Console.WriteLine("Senha não deu boa");
            return false;
        }

        return true;
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
            Email = email
        };
        
        response.Ativo = user is not null;
        
        return response; 
    }

    private async Task<UsuarioLoginResponse> GerarCredenciais(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        var acessTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: true);
        var refreshTokenClaims = await ObterClaims(user, adicionarClaimsUsuario: false);

        var dataExpiracaoAcessToken = DateTime.UtcNow.AddSeconds(_jwtSettings.AccesTokenExpiration);
        var dataExpiracaoRefreshToken = DateTime.UtcNow.AddSeconds(_jwtSettings.RefreshTokenExpiration);

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
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var jwt = new JwtSecurityToken(
            issuer: _jwtSettings.Issuer,
            audience: _jwtSettings.Audience,
            claims: claims,
            notBefore: DateTime.UtcNow,
            expires: dataExpiracao,
            signingCredentials: signingCredentials
        );

        return new JwtSecurityTokenHandler().WriteToken(jwt);
    }


    private async Task<IList<Claim>> ObterClaims(IdentityUser user, bool adicionarClaimsUsuario)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(JwtRegisteredClaimNames.Nbf, ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString()),
            new Claim(JwtRegisteredClaimNames.Iat, ((DateTimeOffset)DateTime.UtcNow).ToUnixTimeSeconds().ToString())

        };

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

}