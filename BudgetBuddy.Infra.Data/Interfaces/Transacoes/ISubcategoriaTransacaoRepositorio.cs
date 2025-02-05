using BudgetBuddy.Domain.Entities.Transactions;

namespace BudgetBuddy.Infra.Data.Interfaces.Transacoes
{
    public interface ISubcategoriaTransacaoRepositorio : IRepositorioBase<SubcategoriaTransacao>
    {
        public IList<SubcategoriaTransacao> GetByCategoriaId(int categoriaId);
        public Task<bool> IsSubcategoriaExistente(string nome, int? idCategoria);
    }
}
