using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ISubcategoriaTransacaoService
    {
        List<SubcategoriaTransacaoTableDto> GetAll();
        SubcategoriaTransacaoTableDto GetById(int id);
        int Add(SubcategoriaTransacaoFormInsertDto dto);
        void Update(SubcategoriaTransacaoFormUpdateDto dto);
        void Delete(int id);
    }
}
