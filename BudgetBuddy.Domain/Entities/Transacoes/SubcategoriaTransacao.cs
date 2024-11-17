namespace BudgetBuddy.Domain.Entities.Transactions
{
    public class SubcategoriaTransacao : EntityBase
    {
        public string Nome { get; set; }
        public int CategoriaTransacaoId { get; set; }
        public CategoriaTransacao CategoriaTransacao { get; set; }
    }
}
