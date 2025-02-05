namespace BudgetBuddy.Application.Dtos.Usuarios;

public class UsuarioDto
{
    public string? Nome { get; set; }
    public string? Senha { get; set; }
    public string? RefreshToken { get; set; }
    public string? Email { get; set; }
}