using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Entities.Usuarios;
using BudgetBuddy.Domain.Enums;

namespace BudgetBuddy.Domain.Entities.Transactions
{
    public class Transacao : EntityBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public bool Status { get; set; }
        public DateTime? DataPrevista { get; set; }
        public DateTime? DataEfetivacao { get; set; }
        public int IdContaBancaria { get; set; }
        public int IdSubcategoriaTransacao { get; set; } 
        public virtual ContaBancaria ContaBancaria { get; set; }
        public virtual SubcategoriaTransacao SubcategoriaTransacao { get; set; }
        public virtual Usuario Usuario { get; set; }

    }
}
