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

        public int Add(ContaBancariaFormInsertDto dto)
        {
            var conta = new ContaBancaria
            {
                Nome = dto.Nome,
                Saldo = dto.Saldo,
                Icon = dto.Icon,
                IdCategoria = dto.IdCategoria,
            };
            _repositorio.Add(conta);
            return conta.Id;
        }

        public void Delete(int id)
        {
            var conta = _repositorio.GetById(id);
            if (conta is null)
                throw new Exception("Conta bancária não encontrada");

            conta.RegistroAtivo = false;
            _repositorio.Delete(conta);
        }

        public List<ContaBancariaTableDto> GetAll()
        {
            var contas = _repositorio.GetAll();
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

        public ContaBancariaTableDto GetById(int id)
        {
            var conta = _repositorio.GetById(id);
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

        public void Update(ContaBancariaFormUpdateDto dto)
        {
            var conta = _repositorio.GetById(dto.Id);
            if (conta is null)
                throw new Exception("Conta bancária não encontrada");


            conta.Id = dto.Id;
            conta.Nome = dto.Nome;
            conta.Saldo = dto.Saldo;
            conta.Icon = dto.Icon;
            conta.IdCategoria = dto.IdCategoria;

            _repositorio.Update(conta);
        }
        
        public void UpdateSaldo(int id, decimal valor)
        {
            var conta = _repositorio.GetById(id);
            if (conta is null)
                throw new Exception("Conta bancária não encontrada");
                
            conta.Saldo += valor;
            
            _repositorio.Update(conta);
        }
    }
}
