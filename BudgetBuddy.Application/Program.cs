using BudgetBuddy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigin",
        builder => builder.WithOrigins("http://localhost:4200") // URL do seu frontend
                          .AllowAnyHeader()
                          .AllowAnyMethod());
});

builder.Services.AddDbContext<BudgetBuddyContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("SqlServer")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowSpecificOrigin"); // Aplicando a pol�tica de CORS aqui


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
using (var scopo = app.Services.CreateScope())
{
    // Ir� aplicar automaticamente as migra��es quando a aplica��o subir,
    // ou seja, vai criar o banco de dados com as tabelas mapeadas
    var contexto = scopo.ServiceProvider.GetService<BudgetBuddyContext>();
    contexto?.Database.Migrate();
}


app.Run();
