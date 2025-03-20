using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Dtos.ContasBancarias.Tables;
using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Interfaces.ContasBancarias;

namespace BudgetBuddy.Service.Services.ContasBancarias
{
    public class ContaBancariaService : IContaBancariaService
    {
        private readonly IContaBancariaRepositorio _repositorio;

        public ContaBancariaService(IContaBancariaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<int> AddAsync(string userId, ContaBancariaFormInsertDto dto)
        {
            var conta = new ContaBancaria
            {
                Nome = dto.Nome,
                Saldo = dto.Saldo,
                Icon = dto.Icon,
                IdCategoria = dto.IdCategoria,
            };
            await _repositorio.AddAsync(userId, conta);
            return conta.Id;
        }

        public async Task DeleteAsync(string userId, int id)
        {
            var conta = await _repositorio.GetByIdAsync(userId, id);
            if (conta is null)
                throw new Exception("Conta bancária não encontrada");

            conta.RegistroAtivo = false;
            await _repositorio.DeleteAsync(userId, conta);
        }

        public async Task<List<ContaBancariaTableDto>> GetAllAsync(string userId)
        {
            var contas = await _repositorio.GetAllAsync(userId);
            var dtos = new List<ContaBancariaTableDto>();

            foreach (var conta in contas)
            {
                var dto = new ContaBancariaTableDto
                {
                    Id = conta.Id,
                    Nome = conta.Nome,
                    Saldo = conta.Saldo,
                    Icon = conta.Icon,
                    IdCategoria = conta.IdCategoria,
                };

                dtos.Add(dto);
            }
            return dtos;
        }

        public async Task<ContaBancariaTableDto> GetByIdAsync(string userId, int id)
        {
            var conta = await _repositorio.GetByIdAsync(userId, id);
            if (conta is null)
                return null;

            return new ContaBancariaTableDto
            {
                Id = conta.Id,
                Nome = conta.Nome,
                Saldo = conta.Saldo,
                Icon = conta.Icon,
                IdCategoria = conta.IdCategoria,
            };
        }

        public async Task UpdateAsync(string userId, ContaBancariaFormUpdateDto dto)
        {
            var conta = await _repositorio.GetByIdAsync(userId, dto.Id);
            if (conta is null)
                throw new Exception("Conta bancária não encontrada");

            conta.Nome = dto.Nome;
            conta.Saldo = dto.Saldo;
            conta.Icon = dto.Icon;
            conta.IdCategoria = dto.IdCategoria;

            await _repositorio.UpdateAsync(userId, conta);
        }
        
        public async Task UpdateSaldoAsync(string userId, int id, decimal valor)
        {
            var conta = await _repositorio.GetByIdAsync(userId, id);
            if (conta is null)
                throw new Exception("Conta bancária não encontrada");
                
            conta.Saldo += valor;
            
            await _repositorio.UpdateAsync(userId, conta);
        }
    }
}
