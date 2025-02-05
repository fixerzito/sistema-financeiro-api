using System.ComponentModel.DataAnnotations;

namespace BudgetBuddy.Domain.Dtos.Requests;

public class UsuarioCadastroRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [EmailAddress(ErrorMessage = "O campo {0} é inválido")]
    public string Email { get; set; }
    
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    public string Senha { get; set; }
    
    [Compare(nameof(Senha), ErrorMessage = "As senhas devem ser iguais")]
    public string SenhaConfirmacao { get; set; }
}