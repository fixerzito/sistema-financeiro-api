namespace BudgetBuddy.Domain.Dtos.Usuarios;

public class UsuarioVerifyResponse
{
    public string? Email { get; set; }
    public bool Ativo { get; set; }
}