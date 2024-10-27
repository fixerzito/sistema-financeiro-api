using BudgetBuddy.Domain.Entities.BankAccounts;

namespace BudgetBuddy.Infra.Data.Repositories.ContasBancarias
{
    public interface ICategoriaContaBancariaRepositorio
    {
        List<CategoriaContaBancaria> GetAll();
        CategoriaContaBancaria? GetById(int id);
        CategoriaContaBancaria Add(CategoriaContaBancaria categoria);
        void Delete(CategoriaContaBancaria categoria);
        void Update(CategoriaContaBancaria categoria);
    }
}