using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.Usuario;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.Usuario;

public class UsuarioRepositorio : RepositorioBase<Domain.Entities.Usuarios.Usuario>, IUsuarioRepositorio
{
    private readonly BudgetBuddyContext _contexto;
    private readonly DbSet<Domain.Entities.Usuarios.Usuario> _dbSet;

    public UsuarioRepositorio(BudgetBuddyContext contexto) : base(contexto)
    {
        _contexto = contexto;
        _dbSet = _contexto.Set<Domain.Entities.Usuarios.Usuario>();
    }
    
    public override IList<Domain.Entities.Usuarios.Usuario> GetAll()
    {
        return _dbSet.ToList();
    }

    public override Domain.Entities.Usuarios.Usuario? GetById(int id)
    {
        return _dbSet.FirstOrDefault(x => x.Id == id);
    }
    
    public Domain.Entities.Usuarios.Usuario? GetByName(string nome)
    {
        return _dbSet.FirstOrDefault(x => x.Nome == nome);
    }
}