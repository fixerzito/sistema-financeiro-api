namespace BudgetBuddy.Domain.Entities.BankAccounts
{
    public class ContaBancaria : EntityBase
    {
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public string Icon { get; set; }
        public int IdCategoria { get; set; }
    }
}
