using BudgetBuddy.Domain.Entities.BankAccounts;

namespace BudgetBuddy.Domain.Dtos.Tables
{
    public class TableDto
    {
        public int QuantidadeRegistros { get; set; }
        public List<CategoriaContaBancaria> Dados { get; set; }
    }
}
