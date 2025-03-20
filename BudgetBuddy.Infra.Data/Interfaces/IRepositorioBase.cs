namespace BudgetBuddy.Infra.Data.Interfaces;

public interface IRepositorioBase<T>
{
    Task<IList<T>> GetAllAsync(string userId);  // Agora é async
    Task<T?> GetByIdAsync(string userId, int id);  // Agora é async
    Task<T> AddAsync(string userId, T entidade);  // Agora é async
    Task DeleteAsync(string userId, T entidade);  // Agora é async
    Task UpdateAsync(string userId, T entidade);  // Agora é async
}
