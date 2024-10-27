using BudgetBuddy.Domain.Dtos.Filters;
using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.ContasBancarias
{
    public class CategoriaContaBancariaRepositorio : ICategoriaContaBancariaRepositorio
    {
        private readonly BudgetBuddyContext _context;
        private readonly DbSet<CategoriaContaBancaria> _dbSet;

        public CategoriaContaBancariaRepositorio(BudgetBuddyContext context)
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

        public int Count()
        {
            return _dbSet.Count();
        }

        public List<CategoriaContaBancaria> GetAll(TableFilter filtro)
        {
            var query = _dbSet.AsQueryable();
            //if (!string.IsNullOrEmpty(filtro.Busca))
            //    query = query.Where(x => x.Nome.Contains(filtro.Busca));
            
            //if (filtro.Ordenacao == Ordenacao.Asc)
            //{
            //    query = query.OrderBy(x => x.Nome);
            //} else
            //{
            //    query = query.OrderByDescending(x => x.Nome);
            //}

            //query = query.Take(filtro.Quantidade).Skip(filtro.Pagina) ;

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
