using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BudgetBuddy.Application.DTO.Login;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Interfaces.Usuario;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace BudgetBuddy.Service.Services.Token;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public TokenService(IConfiguration configuration, IUsuarioRepositorio usuarioRepositorio)
    {
        _configuration = configuration;
        _usuarioRepositorio = usuarioRepositorio;
    }

    public string GenerateToken(LoginDto usuario)
    {
        var userDataBase = _usuarioRepositorio.GetByName(usuario.Nome);
        if (usuario.Nome != userDataBase?.Nome || usuario.Senha != userDataBase?.Senha)
            return String.Empty;
        
        var keyString = _configuration["JwtSettings:Key"];
        if (string.IsNullOrWhiteSpace(keyString))
        {
            throw new ArgumentException("A chave JWT não foi configurada ou está vazia.");
        }
        
        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(keyString));
        var issuer = _configuration["JwtSettings:Issuer"];
        var audience = _configuration["JwtSettings:Audience"];
        var expires = _configuration["JwtSettings:AcessTokenExpiration"];
        
        var signingCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new []
            {
                new Claim(type: ClaimTypes.Name, value: userDataBase.Nome),
                new Claim(type: ClaimTypes.Role, value: userDataBase.Permission),
                new Claim(JwtRegisteredClaimNames.Email, userDataBase.Email),
                new Claim(JwtRegisteredClaimNames.Sub, userDataBase.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            },
            expires: DateTime.Now.AddMinutes(Convert.ToInt32(expires)),
            signingCredentials: signingCredentials);
        
        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        
        return token;
    }
}