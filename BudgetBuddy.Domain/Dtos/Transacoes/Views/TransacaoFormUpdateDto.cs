using BudgetBuddy.Domain.Enums;

namespace BudgetBuddy.Domain.Dtos.Transacoes.Views
{
    public class TransacaoViewDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int IdContaBancaria { get; set; }
        public int IdSubcategoriaTransacao { get; set; }
        public int IdCategoriaTransacao { get; set; }
    }
}
