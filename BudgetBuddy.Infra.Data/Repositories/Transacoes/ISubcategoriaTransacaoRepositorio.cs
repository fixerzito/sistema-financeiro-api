using BudgetBuddy.Domain.Entities.Transactions;

namespace BudgetBuddy.Infra.Data.Repositories.Transacoes
{
    public interface ISubcategoriaTransacaoRepositorio
    {
        List<SubcategoriaTransacao> GetAll();
        SubcategoriaTransacao? GetById(int id);
        SubcategoriaTransacao Add(SubcategoriaTransacao subcategoria);
        void Delete(SubcategoriaTransacao subcategoria);
        void Update(SubcategoriaTransacao subcategoria);
    }
}
