using BudgetBuddy.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infra.Data.Mapping.Transacoes
{
    public class SubcategoriaTransacaoMapeamento : IEntityTypeConfiguration<SubcategoriaTransacao>
    {
        public void Configure(EntityTypeBuilder<SubcategoriaTransacao> builder)
        {
            builder.ToTable("subcategoria_transacoes");
            builder.HasKey(subcategoria => subcategoria.Id);

            builder.Property(subcategoria => subcategoria.Nome)
                .IsRequired()
                .HasMaxLength(45);

            builder.HasOne<CategoriaTransacao>()
            .WithMany()
            .HasForeignKey(subcategoria => subcategoria.Categoria);
        }
    }
}
