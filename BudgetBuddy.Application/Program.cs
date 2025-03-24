using System.Text;
using BudgetBuddy.Domain.Entities.Jwt;
using BudgetBuddy.Domain.Entities.Usuarios;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.CartoesCredito;
using BudgetBuddy.Infra.Data.Interfaces.ContasBancarias;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;
using BudgetBuddy.Infra.Data.Interfaces.Usuario;
using BudgetBuddy.Infra.Data.Repositories.CartoesCredito;
using BudgetBuddy.Infra.Data.Repositories.ContasBancarias;
using BudgetBuddy.Infra.Data.Repositories.Transacoes;
using BudgetBuddy.Service.Services.CartoesCredito;
using BudgetBuddy.Service.Services.ContasBancarias;
using BudgetBuddy.Service.Services.Identity;
using BudgetBuddy.Service.Services.Transacoes;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RemoveIdentityRedirects();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo()
    {
        Version = "v1",
        Title = "Admin.Api",
        Description = "Api Administrador",
    });
    
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \n \n \n Type 'Bearer' before insert token"
    });
    
    options.AddSecurityRequirement(new OpenApiSecurityRequirement()
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        corsBuilder => corsBuilder.WithOrigins("http://localhost:4200")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod());
});

builder.Services.AddDbContext<BudgetBuddyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.Configure<IdentityOptions>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
    options.ClaimsIdentity.UserIdClaimType = JwtRegisteredClaimNames.Sub;
    options.User.RequireUniqueEmail = true;
});

builder.Services.AddIdentity<Usuario, IdentityRole>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;
    })
    .AddEntityFrameworkStores<BudgetBuddyContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.ClaimsIdentity.UserIdClaimType = JwtRegisteredClaimNames.Sub;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    // Impedir que o Identity use Cookies de autenticação, já que você está usando JWT
    options.LoginPath = PathString.Empty;
    options.AccessDeniedPath = PathString.Empty;
    options.Events.OnRedirectToLogin = context =>
    {
        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
        return Task.CompletedTask;
    };
    options.Events.OnRedirectToAccessDenied = context =>
    {
        context.Response.StatusCode = StatusCodes.Status403Forbidden;
        return Task.CompletedTask;
    };
});


builder.Services.AddScoped<ICategoriaTransacaoService, CategoriaTransacaoService>();
builder.Services.AddScoped<ISubcategoriaTransacaoService, SubcategoriaTransacaoService>();
builder.Services.AddScoped<ICategoriaContaBancariaService, CategoriaContaBancariaService>();
builder.Services.AddScoped<ICartaoCreditoService, CartaoCreditoService>();
builder.Services.AddScoped<IContaBancariaService, ContaBancariaService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();
builder.Services.AddScoped<IEmailService, EmailService>();

builder.Services.AddScoped<ICategoriaTransacaoRepositorio, CategoriaTransacaoRepositorio>();
builder.Services.AddScoped<ISubcategoriaTransacaoRepositorio, SubcategoriaTransacaoRepositorio>();
builder.Services.AddScoped<ICategoriaContaBancariaRepositorio, CategoriaContaBancariaRepositorio>();
builder.Services.AddScoped<ICartaoCreditoRepositorio, CartaoCreditoRepositorio>();
builder.Services.AddScoped<IContaBancariaRepositorio, ContaBancariaRepositorio>();
builder.Services.AddScoped<ITransacaoRepositorio, TransacaoRepositorio>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.SaveToken = true;
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtSettings:Key"]!)),
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = builder.Configuration["JwtSettings:Issuer"],
            ValidAudience = builder.Configuration["JwtSettings:Audience"],
            ClockSkew = TimeSpan.FromMinutes(5)
        };
        options.Events = new JwtBearerEvents
        {
            OnAuthenticationFailed = context =>
            {
                Console.WriteLine($"Erro na autenticação: {context.Exception.Message}");
                return Task.CompletedTask;
            },
            OnTokenValidated = context =>
            {
                Console.WriteLine("Token validado com sucesso!");
                return Task.CompletedTask;
            }
        };
    });

builder.Logging.AddConsole(); // Adiciona logs no console
builder.Logging.SetMinimumLevel(LogLevel.Debug); // Exibe logs detalhados
builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new Microsoft.AspNetCore.Authorization.AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
        .Build();
    options.DefaultPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme) // Garante que apenas JWT será usado
        .Build();
});


var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin"); ; 
app.Use(async (context, next) =>
{
    var token = context.Request.Headers["Authorization"].ToString();
    if (string.IsNullOrEmpty(token) || !token.StartsWith("Bearer ", StringComparison.OrdinalIgnoreCase))
    {
        Console.WriteLine("Token não fornecido ou formato inválido.");
        await next();
        return;
    }
    
    Console.WriteLine($"Token recebido: {token}");
    await next();
});

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BudgetBuddyContext>();
    context.Database.Migrate();
}

app.Run();
