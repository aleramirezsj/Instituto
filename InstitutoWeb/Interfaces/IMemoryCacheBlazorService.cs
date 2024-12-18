using InstitutoServices.Interfaces;

namespace InstitutoServices.Services.Commons
{
    public interface IMemoryCacheBlazorService
    {
        Task<List<T>> GetAllCacheAsync<T>() where T : class, IEntityWithId;
        Task<bool> DeleteCacheAsync<T>(int id) where T : class, IEntityWithId;
        Task<T> AddCacheAsync<T>(T entity) where T : class, IEntityWithId;
        Task<bool> UpdateCacheAsync<T>(T entity) where T : class, IEntityWithId;
        Task<List<T>> UpdateCacheInBackground<T>() where T : class, IEntityWithId;
        void ClearCache<T>();
        void ClearAllCache();
        void SetCache<T>(string key ,T entity) where T : class, IEntityWithId;
        T GetCache<T>(string key) where T : class, IEntityWithId;
    }
}