using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Response;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ICategoriaTransacaoService
    {
        Task<List<CategoriaTransacaoTableDto>> GetAllAsync(string userId);
        Task<CategoriaTransacaoTableDto> GetByIdAsync(string userId, int id);
        Task<bool> IsCategoriaExistenteAsync(string userId, string nome);
        Task<int> AddAsync(CategoriaTransacaoFormInsertDto dto, string userId);
        Task UpdateAsync(CategoriaTransacaoFormUpdateDto dto, string userId);
        Task DeleteAsync(int id, string userId);
        Task<CategoriaTransacaoCadastroRapidoDto> CadastroRapidoAsync(CategoriaTransacaoCadastroRapidoFormInsertDto dto, string userId);
    }
}