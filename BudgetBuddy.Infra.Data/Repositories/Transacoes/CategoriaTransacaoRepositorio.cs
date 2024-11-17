using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.Transacoes
{
    public class CategoriaTransacaoRepositorio : RepositorioBase<CategoriaTransacao>, ICategoriaTransacaoRepositorio
    {
        public CategoriaTransacaoRepositorio(BudgetBuddyContext contexto) : base(contexto)
        {

        }
    }
}
