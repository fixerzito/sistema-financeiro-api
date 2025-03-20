using BudgetBuddy.Domain.Entities.BankAccounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infra.Data.Mapping.ContasBancarias
{
    public class ContaBancariaMapeamento : IEntityTypeConfiguration<ContaBancaria>
    {
        public void Configure(EntityTypeBuilder<ContaBancaria> builder)
        {
            builder.ToTable("contas_bancarias");
            builder.HasKey(contaBancaria => contaBancaria.Id);

            builder.Property(contaBancaria => contaBancaria.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(contaBancaria => contaBancaria.Saldo)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(contaBancaria => contaBancaria.Icon)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne<CategoriaContaBancaria>()
                .WithMany()
                .HasForeignKey(contaBancaria => contaBancaria.IdCategoria);

            builder.Property(contaBancaria => contaBancaria.RegistroAtivo)
                .IsRequired()
                .HasColumnName("registro_ativo")
                .HasColumnType("BIT")
                .HasDefaultValue(true);

            builder.Property(contaBancaria => contaBancaria.DataHoraCriacao)
                .IsRequired()
                .HasColumnName("data_hora_criacao")
                .HasDefaultValueSql("GETDATE()");
            
            builder.HasOne(x => x.Usuario) 
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            // builder.HasData(
            //     new ContaBancaria
            //     {
            //         Id = 150,
            //         Nome = "Conta Corrente Banco A",
            //         Saldo = 5000.00m,
            //         Icon = "pi pi-wallet",
            //         IdCategoria = 100,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     },
            //     new ContaBancaria
            //     {
            //         Id = 151,
            //         Nome = "Conta Poupança Banco B",
            //         Saldo = 2000.00m,
            //         Icon = "pi pi-money-bill",
            //         IdCategoria = 101,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     },
            //     new ContaBancaria
            //     {
            //         Id = 152,
            //         Nome = "Conta Salário Banco C",
            //         Saldo = 3000.00m,
            //         Icon = "pi pi-chart-line",
            //         IdCategoria = 102,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     },
            //     new ContaBancaria
            //     {
            //         Id = 153,
            //         Nome = "Conta de Investimentos Banco D",
            //         Saldo = 15000.00m,
            //         Icon = "pi pi-briefcase",
            //         IdCategoria = 103,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     },
            //     new ContaBancaria
            //     {
            //         Id = 154,
            //         Nome = "Conta de Reserva Banco E",
            //         Saldo = 8000.00m,
            //         Icon = "pi pi-check",
            //         IdCategoria = 104,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     },
            //     new ContaBancaria
            //     {
            //         Id = 155,
            //         Nome = "Conta Conjunta Banco F",
            //         Saldo = 12000.00m,
            //         Icon = "pi pi-times",
            //         IdCategoria = 105,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     },
            //     new ContaBancaria
            //     {
            //         Id = 156,
            //         Nome = "Conta Jurídica Banco G",
            //         Saldo = 25000.00m,
            //         Icon = "pi pi-user",
            //         IdCategoria = 106,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     },
            //     new ContaBancaria
            //     {
            //         Id = 157,
            //         Nome = "Conta Digital Banco H",
            //         Saldo = 4000.00m,
            //         Icon = "pi pi-home",
            //         IdCategoria = 107,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     },
            //     new ContaBancaria
            //     {
            //         Id = 158,
            //         Nome = "Conta de Depósito Banco I",
            //         Saldo = 7000.00m,
            //         Icon = "pi pi-credit-card",
            //         IdCategoria = 108,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     },
            //     new ContaBancaria
            //     {
            //         Id = 159,
            //         Nome = "Conta de Pagamento Banco J",
            //         Saldo = 6000.00m,
            //         Icon = "pi pi-wallet",
            //         IdCategoria = 109,
            //         RegistroAtivo = true,
            //         DataHoraCriacao = new DateTime(2024, 01, 01)
            //     }
            // );
        }
    }
}