using BudgetBuddy.Domain.Entities.CreditCards;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infra.Data.Mapping.CartoesCredito
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

            builder.Property(cartao => cartao.RegistroAtivo)
               .IsRequired()
               .HasColumnName("registro_ativo")
               .HasColumnType("BIT")
               .HasDefaultValue(true);

            builder.Property(cartao => cartao.DataHoraCriacao)
                .IsRequired()
                .HasColumnName("data_hora_criacao")
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(cartao => cartao.ContaBancaria)
               .WithMany()
               .OnDelete(DeleteBehavior.SetNull)
               .HasForeignKey(cartao => cartao.IdContaVinculada);
            
            builder.HasOne(x => x.Usuario) 
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
