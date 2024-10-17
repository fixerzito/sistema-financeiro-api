using BackendSistemaFinanceiro.Entidades.Transacoes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSistemaFinanceiro.Mapeamentos.Transacoes
{
    public class CategoriaTransacaoMapeamento : IEntityTypeConfiguration<CategoriaTransacao>
    {
        public void Configure(EntityTypeBuilder<CategoriaTransacao> builder)
        {
            builder.ToTable("categoria_transacoes");
            builder.HasKey(categoria => categoria.Id);

            builder.Property(categoria => categoria.Nome)
                .IsRequired() 
                .HasMaxLength(45);
        }
    }
}
