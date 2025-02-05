using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Domain.Dtos.Requests;

public class UsuarioCadastroInicialRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [StringLength(11, ErrorMessage = "O CPF deve ter 11 dígitos", MinimumLength = 11)]
    public string Cpf { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    public DateTime DataNascimento { get; set; }
}
