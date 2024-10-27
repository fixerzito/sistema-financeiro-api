using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;
using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Repositories.Transacoes;

namespace BudgetBuddy.Service.Services.Transacoes
{
    public class SubcategoriaTransacaoService : ISubcategoriaTransacaoService
    {
        private readonly ISubcategoriaTransacaoRepositorio _repositorio;

        public SubcategoriaTransacaoService(BudgetBuddyContext contexto)
        {
            _repositorio = new SubcategoriaTransacaoRepositorio(contexto);
        }

        public int Add(SubcategoriaTransacaoFormInsertDto dto)
        {
            var subcategoria = new SubcategoriaTransacao
            {
                Nome = dto.Nome,
                Categoria = dto.Categoria
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
            _repositorio.Delete(subcategoria);
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
                    Categoria = subcategoria.Categoria
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
                Categoria = subcategoria.Categoria
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
            subcategoria.Categoria = dto.Categoria;
            _repositorio.Update(subcategoria);
        }
    }
}
