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

            builder.Property(subcategoria => subcategoria.RegistroAtivo)
                .IsRequired()
                .HasColumnName("registro_ativo")
                .HasColumnType("BIT")
                .HasDefaultValue(true);

            builder.Property(subcategoria => subcategoria.DataHoraCriacao)
                .IsRequired()
                .HasColumnName("data_hora_criacao")
                .HasDefaultValueSql("GETDATE()");

            builder.HasOne(subcategoria => subcategoria.CategoriaTransacao)
                .WithMany()
                .HasForeignKey(subcategoria => subcategoria.CategoriaTransacaoId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(
                new SubcategoriaTransacao
                {
                    Id = 100, Nome = "Transporte Público", CategoriaTransacaoId = 100, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 101, Nome = "Combustível", CategoriaTransacaoId = 100, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 102, Nome = "Manutenção do Carro", CategoriaTransacaoId = 100, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 103, Nome = "Plano de Saúde", CategoriaTransacaoId = 101, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 104, Nome = "Medicamentos", CategoriaTransacaoId = 101, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 105, Nome = "Consultas Médicas", CategoriaTransacaoId = 101, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 106, Nome = "Tratamentos Estéticos", CategoriaTransacaoId = 101, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 107, Nome = "Cortes de Cabelo", CategoriaTransacaoId = 101, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 108, Nome = "Tratamentos Laser", CategoriaTransacaoId = 102, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 109, Nome = "Equipamentos de Laser", CategoriaTransacaoId = 102, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 110, Nome = "Impostos Municipais", CategoriaTransacaoId = 103, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 111, Nome = "Impostos Estaduais", CategoriaTransacaoId = 103, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 112, Nome = "Impostos Federais", CategoriaTransacaoId = 103, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 113, Nome = "Impostos sobre Rendimento", CategoriaTransacaoId = 103, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 114, Nome = "Impostos de Propriedade", CategoriaTransacaoId = 103, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 115, Nome = "Investimentos em Ações", CategoriaTransacaoId = 104, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 116, Nome = "Investimentos Imobiliários", CategoriaTransacaoId = 104, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 117, Nome = "Fundos de Rendimento", CategoriaTransacaoId = 104, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 118, Nome = "Rendimentos de Poupança", CategoriaTransacaoId = 104, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 119, Nome = "Serviços Domésticos", CategoriaTransacaoId = 105, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 120, Nome = "Consultoria", CategoriaTransacaoId = 105, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 121, Nome = "Assinaturas de Serviços", CategoriaTransacaoId = 105, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 122, Nome = "Viagens a Negócios", CategoriaTransacaoId = 106, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 123, Nome = "Viagens de Lazer", CategoriaTransacaoId = 106, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 124, Nome = "Passagens Aéreas", CategoriaTransacaoId = 106, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 125, Nome = "Hospedagem", CategoriaTransacaoId = 106, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 126, Nome = "Saúde Emergencial", CategoriaTransacaoId = 107, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 127, Nome = "Ambulância", CategoriaTransacaoId = 107, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 128, Nome = "Consultas de Urgência", CategoriaTransacaoId = 107, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 129, Nome = "Alimentos de Emergência", CategoriaTransacaoId = 107, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 130, Nome = "Alimentação no Trabalho", CategoriaTransacaoId = 108, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 131, Nome = "Refeições Rápidas", CategoriaTransacaoId = 108, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 132, Nome = "Mercado", CategoriaTransacaoId = 108, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 133, Nome = "Restaurantes", CategoriaTransacaoId = 108, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 134, Nome = "Lanches", CategoriaTransacaoId = 108, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 135, Nome = "Jogos Online", CategoriaTransacaoId = 109, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 136, Nome = "Jogos de Tabuleiro", CategoriaTransacaoId = 109, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 137, Nome = "Cartões de Jogo", CategoriaTransacaoId = 109, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 138, Nome = "Acessórios para Jogos", CategoriaTransacaoId = 109, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                },
                new SubcategoriaTransacao
                {
                    Id = 139, Nome = "Desenvolvimento de Jogos", CategoriaTransacaoId = 109, RegistroAtivo = true,
                    DataHoraCriacao = DateTime.Now
                }
            );
        }
    }
}