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
                .HasDefaultValue(DateTime.Now);
        }
    }
}
