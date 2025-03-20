using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Response;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;
using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;

namespace BudgetBuddy.Service.Services.Transacoes
{
    public class CategoriaTransacaoService : ICategoriaTransacaoService
    {
        private readonly ICategoriaTransacaoRepositorio _repositorio;

        public CategoriaTransacaoService(ICategoriaTransacaoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public async Task<int> AddAsync(CategoriaTransacaoFormInsertDto dto, string userId)
        {
            var categoria = new CategoriaTransacao
            {
                Nome = dto.Nome
            };

            await _repositorio.AddAsync(userId, categoria);
            return categoria.Id;
        }

        public async Task<bool> IsCategoriaExistenteAsync(string userId, string nome)
        {
            return await _repositorio.IsCategoriaExistenteAsync(userId, nome);
        }

        public async Task DeleteAsync(int id, string userId)
        {
            var categoria = await _repositorio.GetByIdAsync(userId, id);
            if (categoria is null)
            {
                throw new Exception("Categoria não encontrada");
            }

            categoria.RegistroAtivo = false;
            await _repositorio.DeleteAsync(userId, categoria);
        }

        public async Task<CategoriaTransacaoCadastroRapidoDto> CadastroRapidoAsync(CategoriaTransacaoCadastroRapidoFormInsertDto dto, string userId)
        {
            var subcategoriaTransacao = new SubcategoriaTransacao()
            {
                Nome = dto.Subcategoria,
            };

            var categoria = new CategoriaTransacao
            {
                Nome = dto.Nome,
                Subcategorias = new List<SubcategoriaTransacao>()
                {
                    subcategoriaTransacao
                }
            };

            await _repositorio.AddAsync(userId, categoria);
            return new CategoriaTransacaoCadastroRapidoDto()
            {
                IdCategoria = categoria.Id,
                IdSubcategoria = subcategoriaTransacao.Id,
            };
        }

        public async Task<List<CategoriaTransacaoTableDto>> GetAllAsync(string userId)
        {
            var categorias = await _repositorio.GetAllAsync(userId);
            var dtos = new List<CategoriaTransacaoTableDto>();

            foreach (var categoria in categorias)
            {
                var dto = new CategoriaTransacaoTableDto
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome
                };

                dtos.Add(dto);
            }

            return dtos;
        }

        public async Task<CategoriaTransacaoTableDto> GetByIdAsync(string userId, int id)
        {
            var categoria = await _repositorio.GetByIdAsync(userId, id);
            if (categoria is null)
            {
                return null;
            }

            return new CategoriaTransacaoTableDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome
            };
        }

        public async Task UpdateAsync(CategoriaTransacaoFormUpdateDto dto, string userId)
        {
            var categoria = await _repositorio.GetByIdAsync(userId, dto.Id);
            if (categoria is null)
            {
                throw new Exception("Categoria não encontrada");
            }

            categoria.Nome = dto.Nome;
            await _repositorio.UpdateAsync(userId, categoria);
        }
    }
}
