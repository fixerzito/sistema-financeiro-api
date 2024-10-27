using BudgetBuddy.Domain.Dtos.Filters;
using BudgetBuddy.Domain.Entities.BankAccounts;

namespace BudgetBuddy.Infra.Data.Repositories.ContasBancarias
{
    public interface ICategoriaContaBancariaRepositorio
    {
        List<CategoriaContaBancaria> GetAll(TableFilter filtro);
        CategoriaContaBancaria? GetById(int id);
        CategoriaContaBancaria Add(CategoriaContaBancaria categoria);
        void Delete(CategoriaContaBancaria categoria);
        void Update(CategoriaContaBancaria categoria);
        int Count();
    }
}