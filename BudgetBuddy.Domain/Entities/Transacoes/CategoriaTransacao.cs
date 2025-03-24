using BudgetBuddy.Domain.Entities.Usuarios;

namespace BudgetBuddy.Domain.Entities.Transactions
{
    public class CategoriaTransacao : EntityBase
    {
        public string Nome { get; set; }
        public ICollection<SubcategoriaTransacao> Subcategorias { get; set; }
        public virtual Usuario Usuario { get; set; }
    }
}
