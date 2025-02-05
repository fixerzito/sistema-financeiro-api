using BudgetBuddy.Domain.Entities.Usuarios;

namespace BudgetBuddy.Domain.Entities.BankAccounts
{
    public class ContaBancaria : EntityBase
    {
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
        public string Icon { get; set; }
        public int IdCategoria { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
