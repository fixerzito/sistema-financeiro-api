using BudgetBuddy.Domain.Entities.Transactions;
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
            
            builder.HasMany(categoria => categoria.Subcategorias)
                .WithOne(subcategoria => subcategoria.CategoriaTransacao)
                .HasForeignKey(subcategoria => subcategoria.CategoriaTransacaoId);

            builder.Property(categoria => categoria.DataHoraCriacao)
                .IsRequired()
                .HasColumnName("data_hora_criacao")
                .HasDefaultValueSql("GETDATE()");
            
            builder.HasOne(x => x.Usuario)
                .WithMany(u => u.CategoriaTransacao)
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // builder.HasData(
            //     new CategoriaTransacao
            //         { Id = 100, Nome = "Transporte", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) },
            //     new CategoriaTransacao
            //         { Id = 101, Nome = "Saúde", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) },
            //     new CategoriaTransacao
            //         { Id = 102, Nome = "Laser", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) },
            //     new CategoriaTransacao
            //         { Id = 103, Nome = "Impostos", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) },
            //     new CategoriaTransacao
            //         { Id = 104, Nome = "Rendimentos", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) },
            //     new CategoriaTransacao
            //         { Id = 105, Nome = "Serviços", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) },
            //     new CategoriaTransacao
            //         { Id = 106, Nome = "Viagens", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) },
            //     new CategoriaTransacao
            //         { Id = 107, Nome = "Emergências", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) },
            //     new CategoriaTransacao
            //         { Id = 108, Nome = "Alimentação", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) },
            //     new CategoriaTransacao
            //         { Id = 109, Nome = "Jogos", RegistroAtivo = true, DataHoraCriacao = new DateTime(2024, 01, 01) }
            // );
        }
    }
}