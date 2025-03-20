using BudgetBuddy.Domain.Dtos.Transacoes.Dropdown;
using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ISubcategoriaTransacaoService
    {
        Task<List<SubcategoriaTransacaoTableDto>> GetAllAsync(string userId);
        Task<SubcategoriaTransacaoTableDto> GetByIdAsync(string userId, int id);
        Task<bool> IsSubcategoriaExistenteAsync(string userId, string nome, int? idCategoria);
        Task<int> AddAsync(string userId, SubcategoriaTransacaoFormInsertDto dto);
        Task UpdateAsync(string userId, SubcategoriaTransacaoFormUpdateDto dto);
        Task DeleteAsync(string userId, int id);
        Task<IList<SubcategoriaTransacaoDropdownDto>> GetByCategoriaIdAsync(string userId, int categoriaId);
    }
}