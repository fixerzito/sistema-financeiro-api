using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Entities.CreditCards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
