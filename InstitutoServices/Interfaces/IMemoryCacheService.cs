using InstitutoServices.Interfaces;

namespace InstitutoServices.Services.Commons
{
    public interface IMemoryCacheService
    {
        Task<List<T>> GetAllCacheAsync<T>() where T : class, IEntityWithId;
        Task<bool> DeleteCacheAsync<T>(int id) where T : class, IEntityWithId;
        Task<T> AddCacheAsync<T>(T entity) where T : class, IEntityWithId;
        Task<bool> UpdateCacheAsync<T>(T entity) where T : class, IEntityWithId;
        void ClearCache<T>();
    }
}