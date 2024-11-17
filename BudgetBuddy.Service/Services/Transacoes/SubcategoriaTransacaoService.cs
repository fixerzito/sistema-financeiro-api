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

        public int Add(SubcategoriaTransacaoFormInsertDto dto)
        {
            var subcategoria = new SubcategoriaTransacao
            {
                Nome = dto.Nome,
                CategoriaTransacaoId = dto.Categoria
            };

            _repositorio.Add(subcategoria);
            return subcategoria.Id;
        }

        public void Delete(int id)
        {
            var subcategoria = _repositorio.GetById(id);
            if (subcategoria is null)
            {
                throw new Exception("Subcategoria não encontrada");
            }
            subcategoria.RegistroAtivo = false;
            _repositorio.Delete(subcategoria);
        }

        public IList<SubcategoriaTransacaoDropdownDto> GetByCategoriaId(int categoriaId)
        {
            var subcategorias = _repositorio.GetByCategoriaId(categoriaId);
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

        public List<SubcategoriaTransacaoTableDto> GetAll()
        {
            var subcategorias = _repositorio.GetAll();
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

        public SubcategoriaTransacaoTableDto GetById(int id)
        {
            var subcategoria = _repositorio.GetById(id);
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

        public void Update(SubcategoriaTransacaoFormUpdateDto dto)
        {
            var subcategoria = _repositorio.GetById(dto.Id);
            if (subcategoria is null)
            {
                throw new Exception("Categoria não encontrada");
            }

            subcategoria.Nome = dto.Nome;
            subcategoria.CategoriaTransacaoId = dto.Categoria;
            _repositorio.Update(subcategoria);
        }
    }
}
