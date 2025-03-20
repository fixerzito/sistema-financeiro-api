using BudgetBuddy.Domain.Entities;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories;

public class RepositorioBase<T> : IRepositorioBase<T> where T : EntityBase
{
    protected readonly BudgetBuddyContext _contexto;
    protected readonly DbSet<T> _dbSet;

    public RepositorioBase(BudgetBuddyContext contexto)
    {
        _contexto = contexto;
        _dbSet = _contexto.Set<T>();
    }

    public async Task<IList<T>> GetAllAsync(string userId)
    {
        return await _dbSet.Where(x => x.UserId == userId).ToListAsync();
    }

    public async Task<T?> GetByIdAsync(string userId, int id)
    {
        return await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == id);
    }

    public async Task<T> AddAsync(string userId, T entidade)
    {
        entidade.UserId = userId;
        
        await _dbSet.AddAsync(entidade);
        await _contexto.SaveChangesAsync();

        return entidade;
    }

    public async Task DeleteAsync(string userId, T entidade)
    {
        var entidadeExistente = await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == entidade.Id);
        if (entidadeExistente != null)
        {
            entidadeExistente.RegistroAtivo = false;
            _dbSet.Update(entidadeExistente);
            await _contexto.SaveChangesAsync();
        }
    }

    public async Task UpdateAsync(string userId, T entidade)
    {
        var entidadeExistente = await _dbSet.FirstOrDefaultAsync(x => x.UserId == userId && x.Id == entidade.Id);
        if (entidadeExistente != null)
        {
            _dbSet.Update(entidadeExistente);
            await _contexto.SaveChangesAsync();
        }
    }
}
