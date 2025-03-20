using BudgetBuddy.Domain.Dtos.Transacoes.Dropdown;
using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;
using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;

namespace BudgetBuddy.Service.Services.Transacoes
{
    public class SubcategoriaTransacaoService : ISubcategoriaTransacaoService
    {
        private readonly ISubcategoriaTransacaoRepositorio _repositorio;

        public SubcategoriaTransacaoService(ISubcategoriaTransacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<int> AddAsync(string userId, SubcategoriaTransacaoFormInsertDto dto)
        {
            var subcategoria = new SubcategoriaTransacao
            {
                Nome = dto.Nome,
                CategoriaTransacaoId = dto.IdCategoria
            };

            await _repositorio.AddAsync(userId, subcategoria);
            return subcategoria.Id;
        }

        public async Task DeleteAsync(string userId, int id)
        {
            var subcategoria = await _repositorio.GetByIdAsync(userId, id);
            if (subcategoria is null)
            {
                throw new Exception("Subcategoria não encontrada");
            }
            subcategoria.RegistroAtivo = false;
            await _repositorio.DeleteAsync(userId, subcategoria);
        }
        
        public async Task<bool> IsSubcategoriaExistenteAsync(string userId, string nome, int? idCategoria)
        {
            return await _repositorio.IsSubcategoriaExistenteAsync(nome, idCategoria, userId);
        }

        public async Task<IList<SubcategoriaTransacaoDropdownDto>> GetByCategoriaIdAsync(string userId, int categoriaId)
        {
            var subcategorias = await _repositorio.GetByCategoriaIdAsync(userId, categoriaId);
            var dtos = new List<SubcategoriaTransacaoDropdownDto>();

            foreach (var subcategoria in subcategorias)
            {
                var dto = new SubcategoriaTransacaoDropdownDto
                {
                    Id = subcategoria.Id,
                    Nome = subcategoria.Nome
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<List<SubcategoriaTransacaoTableDto>> GetAllAsync(string userId)
        {
            var subcategorias = await _repositorio.GetAllAsync(userId);
            var dtos = new List<SubcategoriaTransacaoTableDto>();

            foreach (var subcategoria in subcategorias)
            {
                var dto = new SubcategoriaTransacaoTableDto
                {
                    Id = subcategoria.Id,
                    Nome = subcategoria.Nome,
                    Categoria = subcategoria.CategoriaTransacaoId
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<SubcategoriaTransacaoTableDto> GetByIdAsync(string userId, int id)
        {
            var subcategoria = await _repositorio.GetByIdAsync(userId, id);
            if (subcategoria is null)
            {
                return null;
            }

            return new SubcategoriaTransacaoTableDto
            {
                Id = subcategoria.Id,
                Nome = subcategoria.Nome,
                Categoria = subcategoria.CategoriaTransacaoId
            };
        }

        public async Task UpdateAsync(string userId, SubcategoriaTransacaoFormUpdateDto dto)
        {
            var subcategoria = await _repositorio.GetByIdAsync(userId, dto.Id);
            if (subcategoria is null)
            {
                throw new Exception("Categoria não encontrada");
            }

            subcategoria.Nome = dto.Nome;
            subcategoria.CategoriaTransacaoId = dto.Categoria;
            await _repositorio.UpdateAsync(userId, subcategoria);
        }
    }
}
