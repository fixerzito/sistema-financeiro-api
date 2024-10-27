using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.Transacoes
{
    public class CategoriaTransacaoRepositorio : ICategoriaTransacaoRepositorio
    {
        private readonly BudgetBuddyContext _contexto;
        private readonly DbSet<CategoriaTransacao> _dbSet;

        public CategoriaTransacaoRepositorio(BudgetBuddyContext contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<CategoriaTransacao>();
        }

        public CategoriaTransacao Add(CategoriaTransacao categoria)
        {
            _dbSet.Add(categoria);
            _contexto.SaveChanges();

            return categoria;
        }

        public void Delete(CategoriaTransacao categoria)
        {
            _dbSet.Remove(categoria);
            _contexto.SaveChanges();
        }

        public List<CategoriaTransacao> GetAll()
        {
            return _dbSet.ToList();
        }

        public CategoriaTransacao? GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Update(CategoriaTransacao categoria)
        {
            _dbSet.Update(categoria);
            _contexto.SaveChanges();
        }
    }
}
