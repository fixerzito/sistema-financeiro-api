namespace BackendSistemaFinanceiro.Entidades.ContasBancarias
{
    public class ContaBancaria
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public string Icon { get; set; }
        public int IdCategoria { get; set; }
    }
}
