namespace BudgetBuddy.Infra.Data.Interfaces.Usuario
{
    public interface IUsuarioRepositorio : IRepositorioBase<Domain.Entities.Usuarios.Usuario>
    {
        public Domain.Entities.Usuarios.Usuario? GetByName(string nome);
    }
}