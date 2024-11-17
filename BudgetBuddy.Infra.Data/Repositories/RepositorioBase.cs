using BudgetBuddy.Domain.Entities;
using BudgetBuddy.Infra.Data.Context;
using BudgetBuddy.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BudgetBuddy.Infra.Data.Repositories;

public class RepositorioBase<T> : IRepositorioBase<T> where T : EntityBase
{
    private readonly BudgetBuddyContext _contexto;
    private readonly DbSet<T> _dbSet;

    public RepositorioBase(BudgetBuddyContext contexto)
    {
        _contexto = contexto;
        _dbSet = _contexto.Set<T>();
    }

    public virtual IList<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public virtual T? GetById(int id)
    {
       return _dbSet.FirstOrDefault(x => x.Id == id);
    }

    public T Add(T entidade)
    {
        _dbSet.Add(entidade);
        _contexto.SaveChanges();
        return entidade;
    }

    public void Delete(T entidade)
    {
        entidade.RegistroAtivo = false;
        _dbSet.Update(entidade);
        _contexto.SaveChanges();
    }

    public void Update(T entidade)
    {
        _dbSet.Update(entidade);
        _contexto.SaveChanges();
    }
}