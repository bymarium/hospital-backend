using Hospital.Api.Dtos;
using Hospital.Api.Models;

namespace Hospital.Api.Services.Interfaces
{
  public interface IService<T>
  {
    Task<T> CreateAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdWithDetailsAsync(int id);
  }
}
