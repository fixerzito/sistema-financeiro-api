namespace BudgetBuddy.Domain.Entities.Usuarios
{
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }
        public string Senha { get; set; }
        public string RefreshToken { get; set; }
        public string Email { get; set; }
        public string Permission { get; set; } = "Usuario";
    }
}
