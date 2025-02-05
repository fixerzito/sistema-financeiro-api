namespace BudgetBuddy.Domain.Dtos.ContasBancarias.Tables
{
    public class ContaBancariaTableDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Saldo { get; set; }
        public string Icon { get; set; }
        public int IdCategoria { get; set; }
    }
}
