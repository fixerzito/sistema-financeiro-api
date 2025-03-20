using BudgetBuddy.Domain.Dtos.CartoesCredito.Forms;
using BudgetBuddy.Domain.Dtos.CartoesCredito.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ICartaoCreditoService
    {
        Task<List<CartaoCreditoTableDto>> GetAllAsync(string userId);
        Task<CartaoCreditoFormUpdateDto?> GetByIdAsync(string userId, int id);
        Task<int> AddAsync(string userId, CartaoCreditoFormInsertDto dto);
        Task UpdateAsync(string userId, CartaoCreditoFormUpdateDto dto);
        Task DeleteAsync(string userId, int id);
    }
}