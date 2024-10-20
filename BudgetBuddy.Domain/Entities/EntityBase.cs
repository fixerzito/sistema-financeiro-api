﻿namespace BudgetBuddy.Domain.Entities
{
    public class EntityBase
    {
        public int Id { get; set; }
        public bool? RegistroAtivo { get; set; }
        public int? CriadoPor { get; set; }
        public DateTime? DataHoraCriacao { get; set; }
    }
}
