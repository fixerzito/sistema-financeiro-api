using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Domain.Dtos.Requests;

public class UsuarioLoginRequest
{
    public string Email { get; set; }
    public string Senha { get; set; }
}