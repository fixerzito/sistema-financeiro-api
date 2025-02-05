using BudgetBuddy.Domain.Dtos.Transacoes.Dropdown;
using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;
using BudgetBuddy.Domain.Dtos.Transacoes.Views;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ITransacaoService
    {
        List<TransacaoTableDto> GetAll();
        List<TransacaoDropdown> GetAllDropdown();
        TransacaoViewDto? GetById(int id);
        int Add(TransacaoFormInsertDto dto);
        void Update(TransacaoFormUpdateDto dto);
        void Delete(int id);
    }
}
