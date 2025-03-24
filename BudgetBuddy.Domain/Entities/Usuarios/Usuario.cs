using BudgetBuddy.Domain.Entities.BankAccounts;
using BudgetBuddy.Domain.Entities.CreditCards;
using BudgetBuddy.Domain.Entities.Transactions;
using Microsoft.AspNetCore.Identity;

namespace BudgetBuddy.Domain.Entities.Usuarios
{
    public class Usuario : IdentityUser
    {
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string CPF { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public string RefreshToken { get; set; } = string.Empty;
        public string Permission { get; set; } = "Usuario";
        
        public ICollection<Transacao> Transacoes { get; set; } = new List<Transacao>();
        public ICollection<CategoriaContaBancaria> CategoriaContaBancaria { get; set; } = new List<CategoriaContaBancaria>();
        public ICollection<ContaBancaria> ContasBancarias { get; set; } = new List<ContaBancaria>();
        public ICollection<CartaoCredito> CartaoCredito { get; set; } = new List<CartaoCredito>();
        public ICollection<CategoriaTransacao> CategoriaTransacao { get; set; } = new List<CategoriaTransacao>();
        public ICollection<SubcategoriaTransacao> SubcategoriaTransacao { get; set; } = new List<SubcategoriaTransacao>();
    }
}
