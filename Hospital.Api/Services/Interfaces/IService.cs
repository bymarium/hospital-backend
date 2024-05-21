using Hospital.Api.Dtos;

namespace Hospital.Api.Services.Interfaces
{
  public interface IService<T>
  {
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
  }
}
