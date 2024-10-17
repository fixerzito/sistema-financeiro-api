using BackendSistemaFinanceiro.Entidades.CartoesCredito;
using BackendSistemaFinanceiro.Entidades.ContasBancarias;
using BackendSistemaFinanceiro.Entidades.Transacoes;
using BackendSistemaFinanceiro.Mapeamentos.CartoesCredito;
using BackendSistemaFinanceiro.Mapeamentos.ContasBancarias;
using BackendSistemaFinanceiro.Mapeamentos.Transacoes;
using Microsoft.EntityFrameworkCore;

namespace BackendSistemaFinanceiro.Database
{
    public class SistemaFinanceiroContext : DbContext
    {
        //Transacoes
        public DbSet<CategoriaTransacao> CategoriaTransacao { get; set; }
        public DbSet<SubcategoriaTransacao> SubcategoriaTransacao { get; set; }

        //Contas Bancarias
        public DbSet<CategoriaContaBancaria> CategoriaContaBancaria { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }

        //Cartoes de Credito

        public DbSet<CartaoCredito> CartaoCredito { get; set; }

        public SistemaFinanceiroContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoriaTransacaoMapeamento());
            modelBuilder.ApplyConfiguration(new SubcategoriaTransacaoMapeamento());
            modelBuilder.ApplyConfiguration(new CategoriaContaBancariaMapeamento());
            modelBuilder.ApplyConfiguration(new ContaBancariaMapeamento());
            modelBuilder.ApplyConfiguration(new CartaoCreditoMapeamento());
        }

    }
}
