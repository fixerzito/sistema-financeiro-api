using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Domain.Dtos.Requests;

public class UsuarioCadastroRequest
{
    public string Email { get; set; }
}