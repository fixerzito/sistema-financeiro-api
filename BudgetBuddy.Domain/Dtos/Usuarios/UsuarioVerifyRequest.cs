namespace BudgetBuddy.Domain.Dtos.Usuarios;

public class UsuarioVerifyRequest
{
    public string? EmailCadastrado { get; set; }
    public bool Ativo { get; set; }
}