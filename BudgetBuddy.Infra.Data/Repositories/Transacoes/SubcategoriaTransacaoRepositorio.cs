using BudgetBuddy.Domain.Entities.Transactions;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces.Transacoes;
using BudgetBuddy.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

public class SubcategoriaTransacaoRepositorio : RepositorioBase<SubcategoriaTransacao>, ISubcategoriaTransacaoRepositorio
{
    public SubcategoriaTransacaoRepositorio(BudgetBuddyContext contexto) : base(contexto)
    {
    }

    public async Task<IList<SubcategoriaTransacao>> GetByCategoriaIdAsync(string userId, int categoriaId)
    {
        return await _dbSet
            .Where(x => x.UserId == userId && x.CategoriaTransacaoId == categoriaId)
            .Include(x => x.CategoriaTransacao)
            .ToListAsync();
    }

    public async Task<bool> IsSubcategoriaExistenteAsync(string nome, int? idCategoria, string userId)
    {
        var query = _dbSet.Where(c => c.UserId == userId && c.Nome.ToLower() == nome.ToLower()).AsQueryable();
        if (idCategoria is not null)
        {
            query = query.Where(x => x.CategoriaTransacaoId == idCategoria);
        }

        return await query.AnyAsync();
    }
}