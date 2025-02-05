using BudgetBuddy.Domain.Entities.Usuarios;

namespace BudgetBuddy.Domain.Interfaces;

public interface IUsuarioService
{
    public void AddUsuario(Usuario usuario);
    public Usuario GetByName(string nome);
}