using BudgetBuddy.Domain.Entities.Usuarios;

namespace BudgetBuddy.Domain.Entities.BankAccounts
{
    public class CategoriaContaBancaria : EntityBase
    {
        public string Nome { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
