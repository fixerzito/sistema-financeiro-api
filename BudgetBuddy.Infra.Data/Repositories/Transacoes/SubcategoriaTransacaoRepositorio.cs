using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.Transacoes
{
    public class SubcategoriaTransacaoRepositorio : RepositorioBase<SubcategoriaTransacao>, ISubcategoriaTransacaoRepositorio
    {
        private readonly BudgetBuddyContext _contexto;
        private readonly DbSet<SubcategoriaTransacao> _dbSet;
        
        public SubcategoriaTransacaoRepositorio(BudgetBuddyContext contexto) : base(contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<SubcategoriaTransacao>();
        }

        public IList<SubcategoriaTransacao> GetByCategoriaId(int categoriaId)
        {
            return _dbSet.Include(x => x.CategoriaTransacao).Where(x => x.CategoriaTransacaoId == categoriaId).ToList();
        }
    }
}
