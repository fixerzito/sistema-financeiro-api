﻿namespace BudgetBuddy.Application.ViewModels.Transacoes;

public class TransacaoFormUpdateViewModel
{
    public string? Nome { get; set; }
    public decimal? Valor { get; set; }
    public int? TipoTransacao { get; set; }
    public int? IdContaBancaria { get; set; }
    public int? IdSubcategoriaTransacao { get; set; }
}