using BudgetBuddy.Domain.Entities.CreditCards;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.CartoesCredito;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.CartoesCredito
{
    public class CartaoCreditoRepositorio : RepositorioBase<CartaoCredito>,ICartaoCreditoRepositorio
    {
        private readonly BudgetBuddyContext _contexto;
        private readonly DbSet<CartaoCredito> _dbSet;
        public CartaoCreditoRepositorio(BudgetBuddyContext context) : base(context)
        {
            _contexto = context;
            _dbSet = context.Set<CartaoCredito>();
        }

        public override IList<CartaoCredito> GetAll()
        {
            return _dbSet.Include(x => x.ContaBancaria).ToList();
        }
    }
}
