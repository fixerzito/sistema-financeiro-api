using BackendSistemaFinanceiro.Entidades.ContasBancarias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSistemaFinanceiro.Mapeamentos.ContasBancarias
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
        }  
    }
}
