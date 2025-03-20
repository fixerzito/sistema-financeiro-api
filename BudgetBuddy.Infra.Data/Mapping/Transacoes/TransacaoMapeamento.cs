using BudgetBuddy.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using BudgetBuddy.Domain.Enums;

namespace BudgetBuddy.Infra.Data.Mapping.Transacoes
{
    internal class TransacaoMapeamento : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("transacoes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Nome)
               .IsRequired()
               .HasMaxLength(100);
            
            builder.Property(x => x.TipoTransacao)
                .IsRequired()
                .HasColumnType("int");
            
            builder.Property(x => x.Status)
                .IsRequired()
                .HasColumnType("BIT");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnType("decimal(18, 2)");
            
            builder.Property(t => t.DataPrevista)
                .HasColumnType("datetime2");

            builder.Property(t => t.DataEfetivacao)
                .HasColumnType("datetime2");

            builder.Property(x => x.RegistroAtivo)
               .IsRequired()
               .HasColumnName("registro_ativo")
               .HasColumnType("BIT")
               .HasDefaultValue(true);

            builder.HasOne(x => x.ContaBancaria)
              .WithMany()
              .OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey(x => x.IdContaBancaria);

            builder.HasOne(x => x.SubcategoriaTransacao)
              .WithMany()
              .OnDelete(DeleteBehavior.Restrict)
              .HasForeignKey(x => x.IdSubcategoriaTransacao);
            
            builder.HasOne(x => x.Usuario) 
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            // builder.HasData(
            // new Transacao{ Id = 150,
            //     Nome = "Cooper",
            //     TipoTransacao = TipoTransacao.Saida,
            //     Status = false,
            //     Valor = 250,
            //     DataPrevista = new DateTime(2024, 01, 05),
            //     RegistroAtivo = true,
            //     IdContaBancaria = 158,
            //     IdSubcategoriaTransacao = 132,
            // });

        }
    }
}
