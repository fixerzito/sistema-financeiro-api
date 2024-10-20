﻿using BudgetBuddy.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BudgetBuddy.Infra.Data.Mapping.Transacoes
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

            builder.Property(categoria => categoria.RegistroAtivo)
                 .IsRequired()
                 .HasColumnName("registro_ativo")
                 .HasColumnType("BIT")
                .HasDefaultValue(true);

            builder.Property(categoria => categoria.DataHoraCriacao)
                .IsRequired()
                .HasColumnName("data_hora_criacao")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
