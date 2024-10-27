using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.ContasBancarias
{
    public class ContaBancariaRepositorio : IContaBancariaRepositorio
    {
        private readonly BudgetBuddyContext _context;
        private readonly DbSet<ContaBancaria> _dbSet;

        public ContaBancariaRepositorio(BudgetBuddyContext context)
        {
            _context = context;
            _dbSet = _context.Set<ContaBancaria>();
        }

        public ContaBancaria Add(ContaBancaria conta)
        {
            _dbSet.Add(conta);
            _context.SaveChanges();

            return conta;
        }

        public void Delete(ContaBancaria conta)
        {
            _dbSet.Remove(conta);
            _context.SaveChanges();
        }

        public List<ContaBancaria> GetAll()
        {
            return _dbSet.ToList();
        }

        public ContaBancaria? GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Update(ContaBancaria conta)
        {
            _dbSet.Update(conta);
            _context.SaveChanges();
        }
    }
}
