using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Dtos.ContasBancarias.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ICategoriaContaBancariaService
    {
        Task<List<CategoriaContaBancariaTableDto>> GetAllAsync(string userId);
        Task<CategoriaContaBancariaTableDto?> GetByIdAsync(string userId, int id);
        Task<int> AddAsync(string userId, CategoriaContaBancariaFormInsertDto dto);
        Task UpdateAsync(string userId, CategoriaContaBancariaFormUpdateDto dto);
        Task DeleteAsync(string userId, int id);
    }
}