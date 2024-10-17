using BackendSistemaFinanceiro.Entidades.CartoesCredito;
using BackendSistemaFinanceiro.Entidades.ContasBancarias;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendSistemaFinanceiro.Mapeamentos.CartoesCredito
{
    public class CartaoCreditoMapeamento : IEntityTypeConfiguration<CartaoCredito>
    {
        public void Configure(EntityTypeBuilder<CartaoCredito> builder)
        {
            builder.ToTable("cartoes_credito");
            builder.HasKey(cartao => cartao.Id);

            builder.Property(cartao => cartao.Nome)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(cartao => cartao.DigBandeira)
               .IsRequired()
               .HasMaxLength(100);

            builder.Property(cartao => cartao.Saldo)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(cartao => cartao.Limite)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");

            builder.Property(cartao => cartao.DiaFechamento)
                .IsRequired();

            builder.Property(cartao => cartao.DiaVencimento)
                .IsRequired();

            builder.HasOne(cartao => cartao.ContaBancaria)
               .WithMany()
               .OnDelete(DeleteBehavior.SetNull)
               .HasForeignKey(cartao => cartao.IdContaVinculada);
        }
    }
}
