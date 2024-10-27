using BudgetBuddy.Domain.Entities.BankAccounts;

namespace BudgetBuddy.Infra.Data.Repositories.ContasBancarias
{
    public interface IContaBancariaRepositorio
    {
        List<ContaBancaria> GetAll();
        ContaBancaria? GetById(int id);
        ContaBancaria Add(ContaBancaria conta);
        void Delete(ContaBancaria conta);
        void Update(ContaBancaria conta);
    }
}
