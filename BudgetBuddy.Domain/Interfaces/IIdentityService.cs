using BudgetBuddy.Application.DTO.Login;
using BudgetBuddy.Domain.Dtos.Requests;
using BudgetBuddy.Domain.Dtos.Response;
using BudgetBuddy.Domain.Dtos.Usuarios;

namespace BudgetBuddy.Domain.Interfaces;

public interface IIdentityService
{
    Task<UsuarioCadastroResponse> CadastroInicialAsync(UsuarioCadastroRequest usuarioCadastroRequest);
    Task<bool> CadastrarSenhaAsync(CadastroSenhaRequest request);
    Task<bool> ConfirmarEmailAsync(string token, string email);
    Task<UsuarioLoginResponse> Login (UsuarioLoginRequest usuarioLoginRequest);
    Task<UsuarioLoginResponse> LoginSemSenha(string usuarioId);
    Task<UsuarioVerifyResponse> VerificarEmail(string email);
}