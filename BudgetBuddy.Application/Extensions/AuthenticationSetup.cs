using System.Text;
using BudgetBuddy.Domain.Entities.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace BudgetBuddy.Application.Extensions;

public static class AuthenticationSetup
{
        public static void AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
                var JwtSettingOptions = configuration.GetSection(nameof(JwtSettings));
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("JwtSettings:Key").Value));
                
                services.Configure<JwtSettings>(options =>
                {
                        options.Issuer = JwtSettingOptions.GetSection("JwtSettings:Issuer").Value;
                        options.Audience = JwtSettingOptions.GetSection("JwtSettings:Audience").Value;
                        options.SigningCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                        options.AccesTokenExpiration = int.Parse(JwtSettingOptions.GetSection("JwtSettings:ExpirationMinutes").Value ?? "00");
                        options.RefreshTokenExpiration = int.Parse(JwtSettingOptions.GetSection("JwtSettings:ExpirationMinutes").Value ?? "00");
                });

                services.Configure<IdentityOptions>(options =>
                {
                        options.Password.RequireDigit = true;
                        options.Password.RequireLowercase = true;
                        options.Password.RequireNonAlphanumeric = true;
                        options.Password.RequireUppercase = true;
                        options.Password.RequiredLength = 6;
                });

                var tokenValidationParameters = new TokenValidationParameters
                {
                        ValidateIssuer = true,
                        ValidIssuer = JwtSettingOptions.GetSection("JwtSettings:Issuer").Value,

                        ValidateAudience = true,
                        ValidAudience = JwtSettingOptions.GetSection("JwtSettings:Audience").Value,
                        
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = securityKey,
                        
                        RequireExpirationTime = true,
                        ValidateLifetime = true,
                        
                        ClockSkew = TimeSpan.Zero
                };

                services.AddAuthentication(options =>
                {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                }).AddJwtBearer(options =>
                {
                        options.TokenValidationParameters = tokenValidationParameters;
                });
        }

        // TODO
        // public static void AddAuthorizationPolicies(this IServiceCollection services)
        // {
        //         services.AddSingleton<IAuthorizationHandler, HorarioComercialHandler>();
        //         services.AddAuthorization(options =>
        //         {
        //                 options.AddPolicy(Policies.HorarioComercial, policy => 
        //                         policy.Requirements.Add(new HorarioComercialRequirement));
        //         });
        // }
}