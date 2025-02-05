namespace BudgetBuddy.Infra.Data.Interfaces;

public interface IRepositorioBase<T>
{
    IList<T> GetAll();
    T? GetById(int id);
    T Add(T entidade);
    void Delete(T entidade);
    void Update(T entidade);
}