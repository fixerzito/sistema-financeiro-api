using BudgetBuddy.Domain.Entities.CreditCards;

namespace BudgetBuddy.Infra.Data.Repositories.CartoesCredito
{
    public interface ICartaoCreditoRepositorio
    {
        List<CartaoCredito> GetAll();
        CartaoCredito? GetById(int id);
        CartaoCredito Add(CartaoCredito cartao);
        void Delete(CartaoCredito cartao);
        void Update(CartaoCredito cartao);

    }
}
