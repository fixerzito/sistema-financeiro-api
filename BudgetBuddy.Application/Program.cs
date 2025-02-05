using BudgetBuddy.Domain.Dtos.Usuarios;
using BudgetBuddy.Domain.Entities.Jwt;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.CartoesCredito;
using BudgetBuddy.Infra.Data.Interfaces.ContasBancarias;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;
using BudgetBuddy.Infra.Data.Interfaces.Usuario;
using BudgetBuddy.Infra.Data.Repositories.CartoesCredito;
using BudgetBuddy.Infra.Data.Repositories.ContasBancarias;
using BudgetBuddy.Infra.Data.Repositories.Transacoes;
using BudgetBuddy.Infra.Data.Repositories.Usuario;
using BudgetBuddy.Service.Services.CartoesCredito;
using BudgetBuddy.Service.Services.ContasBancarias;
using BudgetBuddy.Service.Services.Identity;
using BudgetBuddy.Service.Services.Token;
using BudgetBuddy.Service.Services.Transacoes;
using BudgetBuddy.Service.Services.Usuarios;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

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

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<BudgetBuddyContext>()
    .AddDefaultTokenProviders();

builder.Services.AddScoped<ICategoriaTransacaoService, CategoriaTransacaoService>();
builder.Services.AddScoped<ISubcategoriaTransacaoService, SubcategoriaTransacaoService>();
builder.Services.AddScoped<ICategoriaContaBancariaService, CategoriaContaBancariaService>();
builder.Services.AddScoped<ICartaoCreditoService, CartaoCreditoService>();
builder.Services.AddScoped<IContaBancariaService, ContaBancariaService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IIdentityService, IdentityService>();

builder.Services.AddScoped<ICategoriaTransacaoRepositorio, CategoriaTransacaoRepositorio>();
builder.Services.AddScoped<ISubcategoriaTransacaoRepositorio, SubcategoriaTransacaoRepositorio>();
builder.Services.AddScoped<ICategoriaContaBancariaRepositorio, CategoriaContaBancariaRepositorio>();
builder.Services.AddScoped<ICartaoCreditoRepositorio, CartaoCreditoRepositorio>();
builder.Services.AddScoped<IContaBancariaRepositorio, ContaBancariaRepositorio>();
builder.Services.AddScoped<ITransacaoRepositorio, TransacaoRepositorio>();
builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BudgetBuddyContext>();
    context.Database.Migrate();
}

app.Run();
