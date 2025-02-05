using BudgetBuddy.Domain.Entities.Usuarios;

namespace BudgetBuddy.Domain.Entities.BankAccounts
{
    public class CategoriaContaBancaria : EntityBase
    {
        public string Nome { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
