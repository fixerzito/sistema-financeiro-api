using BudgetBuddy.Domain.Entities.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBuddy.Domain.Dtos.CartoesCredito.Tables
{
    public class CartaoCreditoTableDto
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
