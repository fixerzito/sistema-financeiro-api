using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.Transacoes
{
    public class SubcategoriaTransacaoRepositorio : RepositorioBase<SubcategoriaTransacao>,
        ISubcategoriaTransacaoRepositorio
    {
        public SubcategoriaTransacaoRepositorio(BudgetBuddyContext contexto) : base(contexto)
        {
        }

        public IList<SubcategoriaTransacao> GetByCategoriaId(int categoriaId)
        {
            return _dbSet.Include(x => x.CategoriaTransacao).Where(x => x.CategoriaTransacaoId == categoriaId).ToList();
        }

        public async Task<bool> IsSubcategoriaExistente(string nome, int? idCategoria)
        {
            var query = _dbSet.Where(c => c.Nome.ToLower() == nome.ToLower()).AsQueryable();
            if (idCategoria is not null)
            {
                query = query.Where(x => x.CategoriaTransacaoId == idCategoria);
            }

            return await query.AnyAsync();
        }
    }
}