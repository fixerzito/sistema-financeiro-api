using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBuddy.Infra.Data.Repositories.Transacoes
{
    public class SubcategoriaTransacaoRepositorio : ISubcategoriaTransacaoRepositorio
    {
        private readonly BudgetBuddyContext _contexto;
        private readonly DbSet<SubcategoriaTransacao> _dbSet;

        public SubcategoriaTransacaoRepositorio(BudgetBuddyContext contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<SubcategoriaTransacao>();

        }

        public SubcategoriaTransacao Add(SubcategoriaTransacao subcategoria)
        {
            _dbSet.Add(subcategoria);
            _contexto.SaveChanges();

            return subcategoria;
        }

        public void Delete(SubcategoriaTransacao subcategoria)
        {
            _dbSet.Remove(subcategoria);
            _contexto.SaveChanges();
        }

        public List<SubcategoriaTransacao> GetAll()
        {
            return _dbSet.ToList();
        }

        public SubcategoriaTransacao? GetById(int id)
        {
            return _dbSet.FirstOrDefault(x => x.Id == id);
        }

        public void Update(SubcategoriaTransacao subcategoria)
        {
            _dbSet.Update(subcategoria);
            _contexto.SaveChanges();
        }
    }
}
