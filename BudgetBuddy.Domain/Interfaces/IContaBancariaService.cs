using BudgetBuddy.Domain.Dtos.ContasBancarias.Forms;
using BudgetBuddy.Domain.Dtos.ContasBancarias.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface IContaBancariaService
    {
        List<ContaBancariaTableDto> GetAll();
        ContaBancariaTableDto GetById(int id);
        int Add(ContaBancariaFormInsertDto dto);
        void Update(ContaBancariaFormUpdateDto dto);
        void Delete(int id);
        public void UpdateSaldo(int id, decimal valor);
    }
}
