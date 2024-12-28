
using System.Linq.Expressions;

namespace InstitutoServices.Interfaces
{
    public interface IGenericService<T> where T : class
    {
        public Task<List<T>?> GetAllAsync();
        public Task<List<T>?> GetWithFilterAsync(Expression<Func<T, bool>> filter);
        public Task<T?> GetByIdAsync(int id);
        public Task<T?> AddAsync(T? entity);
        public Task<bool> UpdateAsync(T? entity);
        public Task<bool> DeleteAsync(int id);
    }
}
