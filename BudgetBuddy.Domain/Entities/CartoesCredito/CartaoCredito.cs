using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Entities.Usuarios;

namespace BudgetBuddy.Domain.Entities.CreditCards
{
    public class CartaoCredito : EntityBase
    {
        public string Nome { get; set; }
        public string DigBandeira { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public int DiaFechamento { get; set; }
        public int DiaVencimento { get; set; }
        public int? IdContaVinculada { get; set; }
        public virtual ContaBancaria? ContaBancaria { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
