using BudgetBuddy.Domain.Dtos.CartoesCredito.Forms;
using BudgetBuddy.Domain.Dtos.CartoesCredito.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ICartaoCreditoService
    {
        List<CartaoCreditoTableDto> GetAll();
        CartaoCreditoFormUpdateDto? GetById(int id);
        int Add(CartaoCreditoFormInsertDto dto);
        void Update(CartaoCreditoFormUpdateDto dto);
        void Delete(int id);
    }
}
