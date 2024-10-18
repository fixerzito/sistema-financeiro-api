using BudgetBuddy.Infra.Data.Mapping.CartoesCredito;
using BudgetBuddy.Infra.Data.Mapping.ContasBancarias;
using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Entities.CreditCards;
using BudgetBuddy.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using BudgetBuddy.Infra.Data.Mapping.Transacoes;

namespace BudgetBuddy.Infra.Data.Context
{
    public class BudgetBuddyContext : DbContext
    {
        public DbSet<CategoriaTransacao> CategoriaTransacao { get; set; }
        public DbSet<SubcategoriaTransacao> SubcategoriaTransacao { get; set; }

        //Contas Bancarias
        public DbSet<CategoriaContaBancaria> CategoriaContaBancaria { get; set; }
        public DbSet<ContaBancaria> ContaBancaria { get; set; }

        //Cartoes de Credito

        public DbSet<CartaoCredito> CartaoCredito { get; set; }
        public BudgetBuddyContext(DbContextOptions options) : base(options)
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
