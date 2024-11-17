﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetBuddy.Domain.Dtos.Transacoes.Tables
{
    public class TransacaoTableDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string TipoTransacao { get; set; }
        public decimal Valor { get; set; }
        public string ContaBancaria { get; set; }
        public string SubcategoriaTransacao { get; set; }
        public string CategoriaTransacao { get; set; }
    }
}
