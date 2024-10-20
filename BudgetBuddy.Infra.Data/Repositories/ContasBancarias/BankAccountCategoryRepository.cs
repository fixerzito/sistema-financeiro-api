using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.ContasBancarias
{
    public class BankAccountCategoryRepository : IBankAccountCategoryRepository
    {
        private readonly BudgetBuddyContext _context;
        private readonly DbSet<CategoriaContaBancaria> _dbSet;

        public BankAccountCategoryRepository(BudgetBuddyContext context)
        {
            _context = context;
            _dbSet = _context.Set<CategoriaContaBancaria>();
        }

        public CategoriaContaBancaria Add(CategoriaContaBancaria categoria)
        {
            _dbSet.Add(categoria);
            _context.SaveChanges();

            return categoria;
        }

        public void Delete(CategoriaContaBancaria categoria)
        {
            _dbSet.Remove(categoria);
            _context.SaveChanges();
        }

        public List<CategoriaContaBancaria> GetAll()
        {
            return _dbSet.ToList();      
        }

        public CategoriaContaBancaria? GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public void Update(CategoriaContaBancaria categoria)
        {
            _dbSet.Update(categoria);
            _context.SaveChanges();
        }
    }
}
