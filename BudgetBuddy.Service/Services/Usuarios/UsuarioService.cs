using BudgetBuddy.Domain.Entities.Usuarios;
using BudgetBuddy.Domain.Interfaces;
using BudgetBuddy.Infra.Data.Interfaces.Usuario;

namespace BudgetBuddy.Service.Services.Usuarios;

public class UsuarioService : IUsuarioService
{
    private readonly IUsuarioRepositorio _usuarioRepositorio;

    public UsuarioService(IUsuarioRepositorio usuarioRepositorio)
    {
        _usuarioRepositorio = usuarioRepositorio;
    }

    public void AddUsuario(Usuario usuario)
    {
        _usuarioRepositorio.Add(usuario);
    }

    public Usuario GetByName(string nome)
    {
        return _usuarioRepositorio.GetByName(nome) ?? throw new InvalidOperationException();
    }
}