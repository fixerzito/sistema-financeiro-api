using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Domain.Dtos.Requests;

public class UsuarioCadastroRequest
{
    public string Email { get; set; }
    public string CPF { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
}