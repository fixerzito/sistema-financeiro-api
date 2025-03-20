using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Dtos.ContasBancarias.Tables;
using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Interfaces.ContasBancarias;

namespace BudgetBuddy.Service.Services.ContasBancarias
{
    public class CategoriaContaBancariaService : ICategoriaContaBancariaService
    {
        private readonly ICategoriaContaBancariaRepositorio _repository;

        public CategoriaContaBancariaService(ICategoriaContaBancariaRepositorio repository)
        {
            _repository = repository;
        }

        public async Task<int> AddAsync(string userId, CategoriaContaBancariaFormInsertDto dto)
        {
            var categoria = new CategoriaContaBancaria
            {
                Nome = dto.Nome,
            };

            await _repository.AddAsync(userId, categoria);
            return categoria.Id;
        }

        public async Task DeleteAsync(string userId, int id)
        {
            var categoria = await _repository.GetByIdAsync(userId, id);
            if (categoria is null)
                throw new Exception("Categoria não encontrada");

            categoria.RegistroAtivo = false;
            await _repository.DeleteAsync(userId, categoria);
        }

        public async Task<List<CategoriaContaBancariaTableDto>> GetAllAsync(string userId)
        {
            var categorias = await _repository.GetAllAsync(userId);
            var dtos = new List<CategoriaContaBancariaTableDto>();

            foreach (var categoria in categorias)
            {
                var dto = new CategoriaContaBancariaTableDto
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<CategoriaContaBancariaTableDto?> GetByIdAsync(string userId, int id)
        {
            var categoria = await _repository.GetByIdAsync(userId, id);
            if (categoria is null)
                return null;

            return new CategoriaContaBancariaTableDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
            };
        }

        public async Task UpdateAsync(string userId, CategoriaContaBancariaFormUpdateDto dto)
        {
            var categoria = await _repository.GetByIdAsync(userId, dto.Id);
            if (categoria is null)
                throw new Exception("Categoria não encontrada");

            categoria.Nome = dto.Nome;

            await _repository.UpdateAsync(userId, categoria);
        }
    }
}
