using Microsoft.IdentityModel.Tokens;

namespace BudgetBuddy.Domain.Entities.Jwt;

public class JwtSettings
{
    public string Key { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }

    public string ClientUrl { get; set; }
    public SigningCredentials SigningCredentials { get; set; }
    public int AccesTokenExpiration { get; set; }
    public int RefreshTokenExpiration { get; set; }
}