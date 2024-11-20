using BudgetBuddy.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            
        }
    }
}
