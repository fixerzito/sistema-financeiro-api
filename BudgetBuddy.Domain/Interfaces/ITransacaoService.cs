using BudgetBuddy.Domain.Dtos.Transacoes.Dropdown;
using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;
using BudgetBuddy.Domain.Dtos.Transacoes.Views;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ITransacaoService
    {
        Task<List<TransacaoTableDto>> GetAllAsync(string userId);
        Task<List<TransacaoDropdown>> GetAllDropdownAsync(string userId);
        Task<TransacaoViewDto?> GetByIdAsync(string userId, int id);
        Task<int> AddAsync(string userId, TransacaoFormInsertDto dto);
        Task UpdateAsync(string userId, TransacaoFormUpdateDto dto);
        Task DeleteAsync(string userId, int id);
    }
}