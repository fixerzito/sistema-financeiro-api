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
        }
    }
}
