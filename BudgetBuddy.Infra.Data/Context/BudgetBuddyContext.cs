using BudgetBuddy.Domain.Dtos.Usuarios;
using BudgetBuddy.Infra.Data.Mapping.CartoesCredito;
using BudgetBuddy.Infra.Data.Mapping.ContasBancarias;
using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Entities.CreditCards;
using BudgetBuddy.Domain.Entities.Transactions;
using Microsoft.EntityFrameworkCore;
using BudgetBuddy.Infra.Data.Mapping.Transacoes;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Context
{
    public class BudgetBuddyContext : IdentityDbContext
    {
        public BudgetBuddyContext(DbContextOptions<BudgetBuddyContext> options) : base(options) { }

        public DbSet<ContaBancaria> ContaBancaria { get; set; }
        public DbSet<CartaoCredito> CartaoCredito { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CategoriaTransacaoMapeamento());
            modelBuilder.ApplyConfiguration(new SubcategoriaTransacaoMapeamento());
            modelBuilder.ApplyConfiguration(new CategoriaContaBancariaMapeamento());
            modelBuilder.ApplyConfiguration(new ContaBancariaMapeamento());
            modelBuilder.ApplyConfiguration(new CartaoCreditoMapeamento());
            modelBuilder.ApplyConfiguration(new TransacaoMapeamento());

            modelBuilder.Entity<Transacao>()
                .HasQueryFilter(e => e.RegistroAtivo);
            modelBuilder.Entity<SubcategoriaTransacao>()
                .HasQueryFilter(e => e.RegistroAtivo);
            modelBuilder.Entity<CategoriaTransacao>()
                .HasQueryFilter(e => e.RegistroAtivo);
            modelBuilder.Entity<CategoriaContaBancaria>()
                .HasQueryFilter(e => e.RegistroAtivo);
            modelBuilder.Entity<ContaBancaria>()
                .HasQueryFilter(e => e.RegistroAtivo);
            modelBuilder.Entity<CartaoCredito>()
                .HasQueryFilter(e => e.RegistroAtivo);
        }
    }
}
