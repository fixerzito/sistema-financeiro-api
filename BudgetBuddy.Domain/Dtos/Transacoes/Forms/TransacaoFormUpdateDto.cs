﻿using BudgetBuddy.Domain.Dtos.Usuarios;
using BudgetBuddy.Domain.Enums;

namespace BudgetBuddy.Domain.Dtos.Transacoes.Forms
{
    public class TransacaoFormUpdateDto : User
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Status { get; set; }
        public DateTime? DataPrevista { get; set; }
        public DateTime? DataEfetivacao { get; set; }
        public TipoTransacao TipoTransacao { get; set; }
        public int IdContaBancaria { get; set; }
        public int IdSubcategoriaTransacao { get; set; }
    }
}
