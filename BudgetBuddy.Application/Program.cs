using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.CartoesCredito;
using BudgetBuddy.Infra.Data.Interfaces.ContasBancarias;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;
using BudgetBuddy.Infra.Data.Repositories.CartoesCredito;
using BudgetBuddy.Infra.Data.Repositories.ContasBancarias;
using BudgetBuddy.Infra.Data.Repositories.Transacoes;
using BudgetBuddy.Service.Services.CartoesCredito;
using BudgetBuddy.Service.Services.ContasBancarias;
using BudgetBuddy.Service.Services.Transacoes;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        corsBuilder => corsBuilder.WithOrigins("http://localhost:4200")
                                  .AllowAnyHeader()
        .AllowAnyMethod());
});

builder.Services.AddScoped<ICategoriaTransacaoService, CategoriaTransacaoService>();
builder.Services.AddScoped<ISubcategoriaTransacaoService, SubcategoriaTransacaoService>();
builder.Services.AddScoped<ICategoriaContaBancariaService, CategoriaContaBancariaService>();
builder.Services.AddScoped<ICartaoCreditoService, CartaoCreditoService>();
builder.Services.AddScoped<IContaBancariaService, ContaBancariaService>();
builder.Services.AddScoped<ITransacaoService, TransacaoService>();

builder.Services.AddScoped<ICategoriaTransacaoRepositorio, CategoriaTransacaoRepositorio>();
builder.Services.AddScoped<ISubcategoriaTransacaoRepositorio, SubcategoriaTransacaoRepositorio>();
builder.Services.AddScoped<ICategoriaContaBancariaRepositorio, CategoriaContaBancariaRepositorio>();
builder.Services.AddScoped<ICartaoCreditoRepositorio, CartaoCreditoRepositorio>();
builder.Services.AddScoped<IContaBancariaRepositorio, ContaBancariaRepositorio>();
builder.Services.AddScoped<ITransacaoRepositorio, TransacaoRepositorio>();

builder.Services.AddDbContext<BudgetBuddyContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("AllowSpecificOrigin");

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<BudgetBuddyContext>();
    context.Database.Migrate();
}

app.Run();
