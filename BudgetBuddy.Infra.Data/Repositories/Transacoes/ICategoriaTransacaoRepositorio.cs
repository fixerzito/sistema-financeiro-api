using BudgetBuddy.Domain.Entities.Transactions;

namespace BudgetBuddy.Infra.Data.Repositories.Transacoes
{
    public interface ICategoriaTransacaoRepositorio
    {
        List<CategoriaTransacao> GetAll();
        CategoriaTransacao? GetById(int id);
        CategoriaTransacao Add(CategoriaTransacao categoria);
        void Delete(CategoriaTransacao categoria);
        void Update(CategoriaTransacao categoria);
    }
}
