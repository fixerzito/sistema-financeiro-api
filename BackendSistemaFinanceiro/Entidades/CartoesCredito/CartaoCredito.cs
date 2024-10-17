using BackendSistemaFinanceiro.Entidades.ContasBancarias;

namespace BackendSistemaFinanceiro.Entidades.CartoesCredito
{
    public class CartaoCredito
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DigBandeira { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public int DiaFechamento { get; set; }
        public int DiaVencimento{ get; set; }
        public int? IdContaVinculada { get; set; }
        public virtual ContaBancaria? ContaBancaria { get; set; }
    }
}
