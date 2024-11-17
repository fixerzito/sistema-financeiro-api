using BudgetBuddy.Domain.Entities.Transactions;

namespace BudgetBuddy.Infra.Data.Interfaces.Transacoes
{
    public interface ISubcategoriaTransacaoRepositorio : IRepositorioBase<SubcategoriaTransacao>
    {
        public IList<SubcategoriaTransacao> GetByCategoriaId(int categoriaId);
    }
}
