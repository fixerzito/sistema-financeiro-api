using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.ContasBancarias;

namespace BudgetBuddy.Infra.Data.Repositories.ContasBancarias
{
    public class CategoriaContaBancariaRepositorio : RepositorioBase<CategoriaContaBancaria>, ICategoriaContaBancariaRepositorio
    {
        public CategoriaContaBancariaRepositorio(BudgetBuddyContext context) : base(context)
        {

        }   
    }
}
