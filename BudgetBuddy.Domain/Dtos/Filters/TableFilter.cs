namespace BudgetBuddy.Domain.Dtos.Filters
{

    public enum Ordenacao
    {
        Asc = 1, 
        Desc = -1
    }
    public class TableFilter
    {
        public string? Busca { get; set; }
        public int Pagina { get; set; }
        public int Quantidade { get; set; }
        public string OrdenacaoColuna { get; set; }
        public Ordenacao Ordenacao { get; set; }

    }
}
