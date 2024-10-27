using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBuddy.Domain.Dtos.ContasBancarias.Tables
{
    public class ContaBancariaTableDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; set; }
        public string Icon { get; set; }
        public int IdCategoria { get; set; }
    }
}
