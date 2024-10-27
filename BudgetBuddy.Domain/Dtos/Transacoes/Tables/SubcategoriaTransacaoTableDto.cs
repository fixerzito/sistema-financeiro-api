using BudgetBuddy.Domain.Entities.BankAccounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBuddy.Domain.Dtos.Transacoes.Tables
{
    public class SubcategoriaTransacaoTableDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Categoria { get; set; }
    }
}
