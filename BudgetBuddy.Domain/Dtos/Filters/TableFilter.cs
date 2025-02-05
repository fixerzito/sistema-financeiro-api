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

        public TableFilter()
        {
            // Inicialize os valores padrão
            Pagina = 1;
            Quantidade = 10; // Pode ser alterado conforme necessário
            OrdenacaoColuna = "nome"; // Coluna padrão para ordenação
            Ordenacao = Ordenacao.Asc; // Ordem padrão
        }

    }
}
