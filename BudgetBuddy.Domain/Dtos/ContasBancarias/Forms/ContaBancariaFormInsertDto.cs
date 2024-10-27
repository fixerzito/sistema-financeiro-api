namespace BudgetBuddy.Domain.Dtos.ContasBancarias.Forms
{
    public class ContaBancariaFormInsertDto
    {
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public string Icon { get; set; }
        public int IdCategoria { get; set; }
    }
}
