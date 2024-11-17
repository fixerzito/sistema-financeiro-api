using BudgetBuddy.Domain.Entities.Transactions;

namespace BudgetBuddy.Infra.Data.Interfaces.Transacoes
{
    //TODO: Ajustar posteriormnente para que seja transacaoContaBancaria, a princípio será padrão
    public interface ITransacaoRepositorio : IRepositorioBase<Transacao>
    {
        
    }
}
