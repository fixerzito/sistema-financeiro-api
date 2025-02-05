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

        public int Add(CategoriaTransacaoFormInsertDto dto)
        {
            var categoria = new CategoriaTransacao
            {
                Nome = dto.Nome
            };

            _repositorio.Add(categoria);
            return categoria.Id;
        }

        public async Task<bool> IsCategoriaExistente(string nome)
        {
            return await _repositorio.IsCategoriaExistente(nome);
        }

        public void Delete(int id)
        {
            var categoria = _repositorio.GetById(id);
            if (categoria is null)
            {
                throw new Exception("Categoria não encontrada");
            }
            categoria.RegistroAtivo = false;
            _repositorio.Delete(categoria);
        }

        public CategoriaTransacaoCadastroRapidoDto CadastroRapido(CategoriaTransacaoCadastroRapidoFormInsertDto dto)
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

            _repositorio.Add(categoria);
            return new CategoriaTransacaoCadastroRapidoDto()
            {
                IdCategoria = categoria.Id,
                IdSubcategoria = subcategoriaTransacao.Id,
            };
        }

        public List<CategoriaTransacaoTableDto> GetAll()
        {
            var categorias = _repositorio.GetAll();
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

        public CategoriaTransacaoTableDto GetById(int id)
        {
                var categoria = _repositorio.GetById(id);
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

        public void Update(CategoriaTransacaoFormUpdateDto dto)
        {
            var categoria = _repositorio.GetById(dto.Id);
            if (categoria is null)
            {
                throw new Exception("Categoria não encontrada");
            }

            categoria.Nome = dto.Nome;
            _repositorio.Update(categoria);
        }
    }
}
