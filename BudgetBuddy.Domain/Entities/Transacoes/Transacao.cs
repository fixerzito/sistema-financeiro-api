using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Enums;

namespace BudgetBuddy.Domain.Entities.Transactions
{
    //TODO: Ajustar posteriormnente para que seja transacaoContaBancaria, a princípio será padrão
    public class Transacao : EntityBase
    {
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        //public string Tipo { get; set; }
        //public int Status { get; set; }
        //public DateTime DataVencimento { get; set; }
        //public DateTime DataEfetivacao { get; set; }
        public int IdContaBancaria { get; set; }
        public int IdSubcategoriaTransacao { get; set; } 
        public virtual ContaBancaria ContaBancaria { get; set; }
        public virtual SubcategoriaTransacao SubcategoriaTransacao { get; set; }

    }
}
