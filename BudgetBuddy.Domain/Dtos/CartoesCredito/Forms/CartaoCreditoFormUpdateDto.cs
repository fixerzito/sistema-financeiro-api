namespace BudgetBuddy.Domain.Dtos.CartoesCredito.Forms
{
    public class CartaoCreditoFormUpdateDto
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required string DigBandeira { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public int DiaFechamento { get; set; }
        public int DiaVencimento { get; set; }
        public int? IdContaVinculada { get; set; }
    }
}
