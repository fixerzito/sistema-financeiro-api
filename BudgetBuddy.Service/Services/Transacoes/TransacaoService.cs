using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;
using BudgetBuddy.Domain.Dtos.Transacoes.Views;
using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Domain.Enums;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Interfaces.ContasBancarias;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;

namespace BudgetBuddy.Service.Services.Transacoes
{
    public class TransacaoService : ITransacaoService
    {
        private readonly ITransacaoRepositorio _repositorio;
        private readonly IContaBancariaService _contaBancariaService;

        public TransacaoService(ITransacaoRepositorio repositorio, IContaBancariaService contaBancariaService)
        {
            _repositorio = repositorio;
            _contaBancariaService = contaBancariaService;
        }

        public int Add(TransacaoFormInsertDto dto)
        {
            var transacao = new Transacao
            {
                Nome = dto.Nome,
                Valor = dto.Valor,
                TipoTransacao = (TipoTransacao)Enum.ToObject(typeof(TipoTransacao), dto.TipoTransacao),
                IdContaBancaria = dto.IdContaBancaria,
                IdSubcategoriaTransacao = dto.IdSubcategoriaTransacao
            };

            _repositorio.Add(transacao);
            return transacao.Id;
        }


        

        public void Delete(int id)
        {
            var transacao = _repositorio.GetById(id);
            if (transacao is null)
                throw new Exception("Transação não encontrada");

            _repositorio.Delete(transacao);
        }

        public List<TransacaoTableDto> GetAll()
        {
            var transacoes = _repositorio.GetAll();
            var dtos = new List<TransacaoTableDto>();

            foreach (var transacao in transacoes)
            {
                var tipoTransacaoString = "";
                if ((int)transacao.TipoTransacao == 1)
                {
                    tipoTransacaoString = "Entrada";
                }
                else
                {
                    tipoTransacaoString = "Saída";
                }
                
                var dto = new TransacaoTableDto
                {
                    Id = transacao.Id,
                    Nome = transacao.Nome,
                    Valor = transacao.Valor,
                    TipoTransacao = tipoTransacaoString,
                    ContaBancaria = transacao.ContaBancaria.Nome,
                    SubcategoriaTransacao = transacao.SubcategoriaTransacao.Nome,
                    CategoriaTransacao = transacao.SubcategoriaTransacao.CategoriaTransacao.Nome
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public TransacaoViewDto? GetById(int id)
        {
            var transacao = _repositorio.GetById(id);
            if (transacao is null)
                return null;

                return new TransacaoViewDto
                {
                    Id = transacao.Id,
                    Nome = transacao.Nome,
                    Valor = transacao.Valor,
                    TipoTransacao = transacao.TipoTransacao,
                    IdContaBancaria = transacao.IdContaBancaria,
                    IdSubcategoriaTransacao = transacao.IdSubcategoriaTransacao,
                    IdCategoriaTransacao = transacao.SubcategoriaTransacao.CategoriaTransacao.Id
                };
        }

        public void Update(TransacaoFormUpdateDto dto)
        {
            var transacao = _repositorio.GetById(dto.Id);
            if (transacao is null)
                throw new Exception("Transação não encontrada");

            transacao.Nome = dto.Nome;
            transacao.Valor = dto.Valor;
            transacao.TipoTransacao = (TipoTransacao)Enum.ToObject(typeof(TipoTransacao), dto.TipoTransacao);
            transacao.IdSubcategoriaTransacao = dto.IdSubcategoriaTransacao;
            transacao.IdContaBancaria = dto.IdContaBancaria;

            _repositorio.Update(transacao);
        }


        private void x(TransacaoFormUpdateDto dto)
        {
            var transacaoExistente = GetById(dto.Id);
            
            if (transacaoExistente.Valor != dto.Valor ||
                transacaoExistente.TipoTransacao != dto.TipoTransacao ||
                transacaoExistente.IdContaBancaria != dto.IdContaBancaria)
            {
                var valorDiferenca = CalcularDiferenca(transacaoExistente, dto);
                
                if (transacaoExistente.IdContaBancaria != dto.IdContaBancaria)
                {
                    var valorTransacaoExistente = transacaoExistente.Valor;
                    var valorNovo = dto.Valor;
                    if (dto.TipoTransacao == TipoTransacao.Saida)
                    {
                        valorTransacaoExistente *= -1;
                        valorNovo *= -1;
                    }
                    
                    _contaBancariaService.UpdateSaldo(transacaoExistente.IdContaBancaria, valorTransacaoExistente);
                    _contaBancariaService.UpdateSaldo(dto.IdContaBancaria, valorNovo);
                }
                else
                {
                    _contaBancariaService.UpdateSaldo(dto.IdContaBancaria, (decimal)valorDiferenca);
                }
            }
        }
        
        private double CalcularDiferenca(TransacaoViewDto transacaoEditar, TransacaoFormUpdateDto dto)
        {
            double valorDiferenca = 0.00;
            
            if (transacaoEditar.TipoTransacao != dto.TipoTransacao && transacaoEditar.Valor != dto.Valor)
            {
                if (transacaoEditar.Valor > dto.Valor)
                {
                    if (dto.TipoTransacao is TipoTransacao.Entrada)
                    {
                        valorDiferenca = ((double)transacaoEditar.Valor + (double)dto.Valor);
                    }
                    else if (dto.TipoTransacao is TipoTransacao.Saida)
                    {
                        valorDiferenca = -((double)transacaoEditar.Valor + (double)dto.Valor);
                    }
                }
                else
                {
                    if (dto.TipoTransacao is TipoTransacao.Entrada)
                    {
                        valorDiferenca = ((double)transacaoEditar.Valor + (double)dto.Valor);
                    }
                    else if (dto.TipoTransacao is TipoTransacao.Saida){
                        valorDiferenca = -((double)transacaoEditar.Valor + (double)dto.Valor);
                    }
                }
            }
            else if (transacaoEditar.TipoTransacao == dto.TipoTransacao && transacaoEditar.Valor != dto.Valor)
            {
                if (transacaoEditar.Valor > dto.Valor)
                {
                    if (dto.TipoTransacao is TipoTransacao.Entrada)
                    {
                        valorDiferenca = -((double)transacaoEditar.Valor - (double)dto.Valor);
                    }
                    else if (dto.TipoTransacao is TipoTransacao.Saida){
                        valorDiferenca = ((double)transacaoEditar.Valor - (double)dto.Valor);
                    }
                }
                else
                {
                    if (dto.TipoTransacao is TipoTransacao.Entrada)
                    {
                        valorDiferenca = ((double)dto.Valor - (double)transacaoEditar.Valor);
                    }
                    else if (dto.TipoTransacao is TipoTransacao.Saida){
                        valorDiferenca = -((double)dto.Valor - (double)transacaoEditar.Valor);
                    }
                }
            } 
            else if (transacaoEditar.TipoTransacao != dto.TipoTransacao && transacaoEditar.Valor == dto.Valor)
            {
                if (dto.TipoTransacao is TipoTransacao.Entrada)
                {
                    valorDiferenca = (double)transacaoEditar.Valor * 2;
                }
                else if (dto.TipoTransacao is TipoTransacao.Saida){
                    valorDiferenca = (double)transacaoEditar.Valor * -2;
                }
            }
            else
            {
                if (dto.TipoTransacao is TipoTransacao.Entrada)
                {
                    valorDiferenca = (double)transacaoEditar.Valor;
                }
                else if (dto.TipoTransacao is TipoTransacao.Saida)
                {
                    valorDiferenca = -(double)transacaoEditar.Valor;
                }
            }
            return valorDiferenca;
        }
        
    }
}
