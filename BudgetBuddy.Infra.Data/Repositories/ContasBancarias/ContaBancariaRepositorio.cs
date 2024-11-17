using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.ContasBancarias;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.ContasBancarias
{
    public class ContaBancariaRepositorio : RepositorioBase<ContaBancaria>, IContaBancariaRepositorio
    {
        public ContaBancariaRepositorio(BudgetBuddyContext context) : base(context)
        {
            
        }
    }
}
