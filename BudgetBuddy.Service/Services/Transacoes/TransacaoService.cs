using BudgetBuddy.Domain.Dtos.Transacoes.Dropdown;
using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;
using BudgetBuddy.Domain.Dtos.Transacoes.Views;
using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Domain.Enums;
using BudgetBuddy.Domain.Interfaces;
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

        public async Task<int> AddAsync(string userId, TransacaoFormInsertDto dto)
        {
            var transacao = new Transacao
            {
                Nome = dto.Nome,
                Valor = dto.Valor,
                Status = dto.Status,
                DataPrevista = dto.DataPrevista.HasValue ? dto.DataPrevista.Value : (DateTime?)null,
                DataEfetivacao = dto.DataEfetivacao.HasValue ? dto.DataEfetivacao.Value : (DateTime?)null,
                TipoTransacao = (TipoTransacao)Enum.ToObject(typeof(TipoTransacao), dto.TipoTransacao),
                IdContaBancaria = dto.IdContaBancaria,
                IdSubcategoriaTransacao = dto.IdSubcategoriaTransacao,
                UserId = userId
            };
            
            if (transacao.Status)
            {
                if (transacao.TipoTransacao == TipoTransacao.Entrada)
                {
                    _contaBancariaService.UpdateSaldoAsync(userId, transacao.IdContaBancaria, transacao.Valor);
                }
                else if(transacao.TipoTransacao == TipoTransacao.Saida)
                {
                    _contaBancariaService.UpdateSaldoAsync(userId, transacao.IdContaBancaria, -transacao.Valor); 
                }
            }

            await _repositorio.AddAsync(userId, transacao);
            return transacao.Id;
        }

        public async Task DeleteAsync(string userId, int id)
        {
            var transacao = await _repositorio.GetByIdAsync(userId, id);
            if (transacao is null)
                throw new Exception("Transação não encontrada");

            await _repositorio.DeleteAsync(userId, transacao);
        }

        public async Task<List<TransacaoTableDto>> GetAllAsync(string userId)
        {
            var transacoes = await _repositorio.GetAllAsync(userId);
            var dtos = new List<TransacaoTableDto>();

            foreach (var transacao in transacoes)
            {
                var tipoTransacaoString = transacao.TipoTransacao == TipoTransacao.Entrada ? "Entrada" : "Saída";
                
                var dto = new TransacaoTableDto
                {
                    Id = transacao.Id,
                    Nome = transacao.Nome,
                    Valor = transacao.Valor,
                    Status = transacao.Status,
                    DataPrevista = transacao.DataPrevista.HasValue ? transacao.DataPrevista.Value : (DateTime?)null,
                    DataEfetivacao = transacao.DataEfetivacao.HasValue ? transacao.DataEfetivacao.Value : (DateTime?)null,
                    TipoTransacao = tipoTransacaoString,
                    ContaBancaria = transacao.ContaBancaria.Nome,
                    SubcategoriaTransacao = transacao.SubcategoriaTransacao.Nome,
                    CategoriaTransacao = transacao.SubcategoriaTransacao.CategoriaTransacao.Nome
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<List<TransacaoDropdown>> GetAllDropdownAsync(string userId)
        {
            var transacoes = await _repositorio.GetAllAsync(userId);
            var dtos = new List<TransacaoDropdown>();

            foreach (var transacao in transacoes)
            {
                var dto = new TransacaoDropdown
                {
                    Id = transacao.Id,
                    Nome = transacao.Nome,
                    Valor = transacao.Valor,
                    Categoria = transacao.SubcategoriaTransacao.CategoriaTransacao.Nome
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<TransacaoViewDto?> GetByIdAsync(string userId, int id)
        {
            var transacao = await _repositorio.GetByIdAsync(userId, id);
            if (transacao is null)
                return null;

            return new TransacaoViewDto
            {
                Id = transacao.Id,
                Nome = transacao.Nome,
                Valor = transacao.Valor,
                Status = transacao.Status,
                DataPrevista = transacao.DataPrevista.HasValue ? transacao.DataPrevista.Value : (DateTime?)null,
                DataEfetivacao = transacao.DataEfetivacao.HasValue ? transacao.DataEfetivacao.Value : (DateTime?)null,
                TipoTransacao = transacao.TipoTransacao,
                IdContaBancaria = transacao.IdContaBancaria,
                IdSubcategoriaTransacao = transacao.IdSubcategoriaTransacao,
                IdCategoriaTransacao = transacao.SubcategoriaTransacao.CategoriaTransacao.Id
            };
        }

        public async Task UpdateAsync(string userId, TransacaoFormUpdateDto dto)
        {
            var transacao = await _repositorio.GetByIdAsync(userId, dto.Id);
            if (transacao is null)
                throw new Exception("Transação não encontrada");

            if (dto.Status != transacao.Status)
            {
                if (transacao.TipoTransacao == TipoTransacao.Entrada)
                {
                    if(dto.Status)
                        _contaBancariaService.UpdateSaldoAsync(userId, dto.IdContaBancaria, dto.Valor);
                    else
                        _contaBancariaService.UpdateSaldoAsync(userId, transacao.IdContaBancaria, -transacao.Valor);
                }
                else if(transacao.TipoTransacao == TipoTransacao.Saida)
                {
                    if(dto.Status)
                        _contaBancariaService.UpdateSaldoAsync(userId, dto.IdContaBancaria, -dto.Valor);
                    else
                        _contaBancariaService.UpdateSaldoAsync(userId, transacao.IdContaBancaria, transacao.Valor);
                }
            }

            if (dto.Status)
            {
                UpdateSaldo(dto);
            }

            transacao.Nome = dto.Nome;
            transacao.Valor = dto.Valor;
            transacao.Status = dto.Status;
            transacao.DataPrevista = dto.DataPrevista;
            transacao.DataEfetivacao = dto.DataEfetivacao;
            transacao.TipoTransacao = (TipoTransacao)Enum.ToObject(typeof(TipoTransacao), dto.TipoTransacao);
            transacao.IdSubcategoriaTransacao = dto.IdSubcategoriaTransacao;
            transacao.IdContaBancaria = dto.IdContaBancaria;

            await _repositorio.UpdateAsync(userId, transacao);
        }

        private async Task UpdateSaldo(TransacaoFormUpdateDto dto)
        {
            var transacaoExistente = await GetByIdAsync(dto.UserId, dto.Id);
            
            if (transacaoExistente!.Valor != dto.Valor ||
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
                    
                    _contaBancariaService.UpdateSaldoAsync(dto.UserId, transacaoExistente.IdContaBancaria, valorTransacaoExistente);
                    _contaBancariaService.UpdateSaldoAsync(dto.UserId, dto.IdContaBancaria, valorNovo);
                }
                else
                {
                    _contaBancariaService.UpdateSaldoAsync(dto.UserId, dto.IdContaBancaria, (decimal)valorDiferenca);
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

            return valorDiferenca;
        }
    }
}
