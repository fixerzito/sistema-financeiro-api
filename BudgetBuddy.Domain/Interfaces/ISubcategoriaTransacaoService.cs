using BudgetBuddy.Domain.Dtos.Transacoes.Dropdown;
using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ISubcategoriaTransacaoService
    {
        List<SubcategoriaTransacaoTableDto> GetAll();
        SubcategoriaTransacaoTableDto GetById(int id);
        Task<bool> IsSubcategoriaExistente(string nome, int? idCategoria);
        int Add(SubcategoriaTransacaoFormInsertDto dto);
        void Update(SubcategoriaTransacaoFormUpdateDto dto);
        void Delete(int id);
        IList<SubcategoriaTransacaoDropdownDto> GetByCategoriaId(int categoriaId);
    }
}
