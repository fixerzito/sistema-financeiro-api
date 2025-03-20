using BudgetBuddy.Domain.Entities.Transactions;

namespace BudgetBuddy.Infra.Data.Interfaces.Transacoes
{
    public interface ISubcategoriaTransacaoRepositorio : IRepositorioBase<SubcategoriaTransacao>
    {
        public Task<IList<SubcategoriaTransacao>> GetByCategoriaIdAsync(string userId, int categoriaId);
        public Task<bool> IsSubcategoriaExistenteAsync(string nome, int? idCategoria, string userId);
    }
}