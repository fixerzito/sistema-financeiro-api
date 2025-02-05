namespace BudgetBuddy.Domain.Dtos.Usuarios;

public class UsuarioVerifyResponse
{
    public string? EmailCadastrado { get; set; }
    public bool Ativo { get; set; }
}