using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.Transacoes
{
    public class TransacaoRepositorio : RepositorioBase<Transacao>, ITransacaoRepositorio
    {
        private readonly BudgetBuddyContext _contexto;
        private readonly DbSet<Transacao> _dbSet;
        public TransacaoRepositorio(BudgetBuddyContext contexto) : base(contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<Transacao>();
        }

        public override IList<Transacao> GetAll()
        {
            return _dbSet.Include(x => x.ContaBancaria)
                .Include(x => x.SubcategoriaTransacao)
                .ThenInclude(st => st.CategoriaTransacao)
                .ToList();
        }

        public override Transacao? GetById(int id)
        {
            return _dbSet.Include(x => x.SubcategoriaTransacao)
                .ThenInclude(st => st.CategoriaTransacao)
                .FirstOrDefault(x => x.Id == id);
        }
    }
}
