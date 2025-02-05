using BudgetBuddy.Domain.Dtos.Transacoes.Forms;
using BudgetBuddy.Domain.Dtos.Transacoes.Response;
using BudgetBuddy.Domain.Dtos.Transacoes.Tables;

namespace BudgetBuddy.Domain.Interfaces
{
    public interface ICategoriaTransacaoService
    {
        List<CategoriaTransacaoTableDto> GetAll();
        CategoriaTransacaoTableDto GetById(int id);
        Task<bool> IsCategoriaExistente(string nome);
        int Add(CategoriaTransacaoFormInsertDto dto);
        void Update(CategoriaTransacaoFormUpdateDto dto);
        void Delete(int id);
        CategoriaTransacaoCadastroRapidoDto CadastroRapido(CategoriaTransacaoCadastroRapidoFormInsertDto dto);
    }
}
