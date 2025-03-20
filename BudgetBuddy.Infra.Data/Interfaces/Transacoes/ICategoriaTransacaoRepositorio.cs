using BudgetBuddy.Domain.Entities.Transactions;

namespace BudgetBuddy.Infra.Data.Interfaces.Transacoes
{
    public interface ICategoriaTransacaoRepositorio : IRepositorioBase<CategoriaTransacao>
    {
        public Task<bool> IsCategoriaExistenteAsync(string userId, string nome);
    }
}
