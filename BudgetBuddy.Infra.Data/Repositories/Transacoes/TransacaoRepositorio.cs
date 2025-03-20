using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories.Transacoes
{
    public class TransacaoRepositorio : RepositorioBase<Transacao>, ITransacaoRepositorio
    {
        private readonly BudgetBuddyContext _contexto;
        private readonly DbSet<Transacao> _dbSet;
        public TransacaoRepositorio(BudgetBuddyContext contexto) : base(contexto)
        {
            _contexto = contexto;
            _dbSet = _contexto.Set<Transacao>();
        }

        public async Task<IList<Transacao>> GetAllAsync(string userId)
        {
            return await _dbSet
                .Where(x => x.UserId == userId)  // Aqui estamos garantindo que o UserId seja filtrado
                .Include(x => x.ContaBancaria)
                .Include(x => x.SubcategoriaTransacao)
                .ThenInclude(st => st.CategoriaTransacao)
                .ToListAsync();  // Usa ToListAsync para tornar a operação assíncrona
        }


        public async Task<Transacao?> GetById(string userId, int id)
        {
            return await _dbSet
                .Where(x => x.UserId == userId && x.Id == id) 
                .Include(x => x.SubcategoriaTransacao)
                .ThenInclude(st => st.CategoriaTransacao)
                .FirstOrDefaultAsync(); 
        }

    }
}
