namespace BudgetBuddy.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool RegistroAtivo { get; set; } = true;
        public DateTime? DataHoraCriacao { get; set; }
    }
}
