using BudgetBuddy.Domain.Entities.Transactions;

namespace BudgetBuddy.Infra.Data.Interfaces.Transacoes
{
    public interface ICategoriaTransacaoRepositorio : IRepositorioBase<CategoriaTransacao>
    {
        public Task<bool> IsCategoriaExistente(string nome);
    }
}
