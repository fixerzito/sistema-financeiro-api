using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Dtos.ContasBancarias.Tables;
using BudgetBuddy.Domain.Dtos.Filters;
using BudgetBuddy.Domain.Dtos.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ICategoriaContaBancariaService
    {
        TableDto GetAll(TableFilter filtro);
        CategoriaContaBancariaTableDto? GetById(int id);
        int Add(CategoriaContaBancariaFormInsertDto dto);
        void Update(CategoriaContaBancariaFormUpdateDto dto);
        void Delete(int id);
    }
}
