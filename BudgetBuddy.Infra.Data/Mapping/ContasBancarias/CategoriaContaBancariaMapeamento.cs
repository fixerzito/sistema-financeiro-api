using BudgetBuddy.Domain.Entities.BankAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infra.Data.Mapping.ContasBancarias
{
    public class CategoriaContaBancariaMapeamento : IEntityTypeConfiguration<CategoriaContaBancaria>
    {
        public void Configure(EntityTypeBuilder<CategoriaContaBancaria> builder)
        {
            builder.ToTable("categoria_contas_bancarias");
            builder.HasKey(categoria => categoria.Id);

            builder.Property(categoria => categoria.Nome)
                .IsRequired()
                .HasMaxLength(45);

            builder.Property(categoria => categoria.RegistroAtivo)
                .IsRequired()
                .HasColumnName("registro_ativo")
                .HasColumnType("BIT")
                .HasDefaultValue(true);

            builder.Property(categoria => categoria.DataHoraCriacao)
                .IsRequired()
                .HasColumnName("data_hora_criacao")
                .HasDefaultValueSql("GETDATE()");

            builder.HasData(
                new CategoriaContaBancaria
                {
                    Id = 100,
                    Nome = "Conta Corrente",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 101,
                    Nome = "Conta Poupança",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 102,
                    Nome = "Conta Salário",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 103,
                    Nome = "Conta de Investimentos",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 104,
                    Nome = "Conta de Reserva",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 105,
                    Nome = "Conta Conjunta",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 106,
                    Nome = "Conta Jurídica",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 107,
                    Nome = "Conta Digital",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 108,
                    Nome = "Conta de Depósito",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 109,
                    Nome = "Conta de Pagamento",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 110,
                    Nome = "Conta de Investimento Imobiliário",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 111,
                    Nome = "Conta de Previdência",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 112,
                    Nome = "Conta de Fomento",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 113,
                    Nome = "Conta de Pagamento Eletrônico",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 114,
                    Nome = "Conta Universitária",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 115,
                    Nome = "Conta Infantil",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 116,
                    Nome = "Conta de Crédito",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 117,
                    Nome = "Conta de Empréstimo",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 118,
                    Nome = "Conta de Transferência",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new CategoriaContaBancaria
                {
                    Id = 119,
                    Nome = "Conta com Investimento Automático",
                    RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                }
            );
        }
    }
}