using BudgetBuddy.Domain.Dtos.Requests;
using BudgetBuddy.Domain.Dtos.Response;
using BudgetBuddy.Domain.Dtos.Usuarios;

namespace BudgetBuddy.Domain.Interfaces;

public interface IIdentityService
{
    Task<UsuarioCadastroResponse> CadstrarUsuario(UsuarioCadastroRequest usuarioCadastroRequest);
    Task<UsuarioLoginResponse> Login (UsuarioLoginRequest usuarioLoginRequest);
    Task<UsuarioLoginResponse> LoginSemSenha(string usuarioId);
    Task<UsuarioVerifyResponse> VerificarEmail(string email);
}