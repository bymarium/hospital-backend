namespace Hospital.Api.Repositories.Interfaces
{
  public interface IRepository<T>
  {
    Task<T?> CreateAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(T entity);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T?> GetByIdWithDetailsAsync(int id);
  }
}
