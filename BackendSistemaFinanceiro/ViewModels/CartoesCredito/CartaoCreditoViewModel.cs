﻿namespace BackendSistemaFinanceiro.ViewModels.CartoesCredito
{
    public class CartaoCreditoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string DigBandeira { get; set; }
        public double Saldo { get; set; }
        public double Limite { get; set; }
        public int DiaFechamento { get; set; }
        public int DiaVencimento { get; set; }
        public string? ContaVinculada { get; set; }
    }
}
