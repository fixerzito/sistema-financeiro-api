using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Dtos.ContasBancarias.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ICategoriaContaBancariaService
    {
        List<CategoriaContaBancariaTableDto> GetAll();
        CategoriaContaBancariaTableDto? GetById(int id);
        int Add(CategoriaContaBancariaFormInsertDto dto);
        void Update(CategoriaContaBancariaFormUpdateDto dto);
        void Delete(int id);
    }
}
