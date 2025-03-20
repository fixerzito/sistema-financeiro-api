using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Dtos.ContasBancarias.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface IContaBancariaService
    {
        Task<List<ContaBancariaTableDto>> GetAllAsync(string userId);
        Task<ContaBancariaTableDto> GetByIdAsync(string userId, int id);
        Task<int> AddAsync(string userId, ContaBancariaFormInsertDto dto);
        Task UpdateAsync(string userId, ContaBancariaFormUpdateDto dto);
        Task DeleteAsync(string userId, int id);
        Task UpdateSaldoAsync(string userId, int id, decimal valor);
    }
}