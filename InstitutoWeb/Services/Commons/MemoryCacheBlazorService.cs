using InstitutoServices.Interfaces;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.JSInterop;
using System.Text.Json;

namespace InstitutoWeb.Services.Commons
{
    public class MemoryCacheBlazorService: IMemoryCacheBlazorService
    {
        protected readonly IMemoryCache _memoryCache;
        private readonly IJSRuntime _jsRuntime;
        private const string PwaCacheName = "v1";

        public MemoryCacheBlazorService(IJSRuntime jsRuntime, IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
            _jsRuntime = jsRuntime;

        }


        // Método para obtener los datos de la caché
        public virtual async Task<List<T>> GetAllCacheAsync<T>() where T : class, IEntityWithId
        {
            var key = typeof(T).Name;

            if (_memoryCache.TryGetValue(key, out List<T>? cachedList))
            {
                return cachedList;
            }
            // Intentar obtener de la caché de PWA
            var pwaData = await _jsRuntime.InvokeAsync<string>("appHelpers.cacheHelper.getDataFromCache", PwaCacheName, key);
            if (pwaData != null)
            {
                cachedList = JsonSerializer.Deserialize<List<T>>(pwaData);
                // Inicia la actualización en segundo plano
                _ = UpdateCacheInBackground<T>();
                return cachedList;
            }

            var list = await UpdateCacheInBackground<T>();  
            return list;
        }

        public async Task<List<T>> UpdateCacheInBackground<T>() where T : class, IEntityWithId
        {
            var key = typeof(T).Name;

            // Obtener los datos frescos desde el servicio genérico
            IGenericService<T> genericService = new GenericService<T>();
            var list = await genericService.GetAllAsync();
            _memoryCache.Set(key, list);

            // Guardar en la caché de PWA
            await _jsRuntime.InvokeVoidAsync("appHelpers.cacheHelper.saveDataToCache", PwaCacheName, key, JsonSerializer.Serialize(list));

            return list;
        }

        //método para eliminar un dato usando el generic y si lo logra, lo elimina de la caché
        public virtual async Task<bool> DeleteCacheAsync<T>(int id) where T : class, IEntityWithId
        {
            var key = typeof(T).Name;

            IGenericService<T> genericService = new GenericService<T>();
            var result = await genericService.DeleteAsync(id);
            if (result)
            {
                var list = await GetAllCacheAsync<T>();
                var item = list.FirstOrDefault(x => x.Id == id);
                list.Remove(item);
                _memoryCache.Set(key, list);
                await _jsRuntime.InvokeVoidAsync("appHelpers.cacheHelper.saveDataToCache", PwaCacheName, key, JsonSerializer.Serialize(list));

            }
            return result;
        }
        //método para agregar un dato usando el generic y si lo logra, lo agrega a la caché
        public virtual async Task<T> AddCacheAsync<T>(T entity) where T : class, IEntityWithId
        {
            var key = typeof(T).Name;

            IGenericService<T> genericService = new GenericService<T>();
            var result = await genericService.AddAsync(entity);
            if (result != null)
            {
                var list = await GetAllCacheAsync<T>();
                list.Add(result);
                _memoryCache.Set(key, list);
                await _jsRuntime.InvokeVoidAsync("appHelpers.cacheHelper.saveDataToCache", PwaCacheName, key, JsonSerializer.Serialize(list));

            }
            return result;
        }
        //método para actualizar un dato usando el generic y si lo logra, lo actualiza en la caché
        public virtual async Task<bool> UpdateCacheAsync<T>(T entity) where T : class, IEntityWithId
        {
            var key = typeof(T).Name;

            IGenericService<T> genericService = new GenericService<T>();
            var result = await genericService.UpdateAsync(entity);
            if (result)
            {
                var list = await GetAllCacheAsync<T>();
                var item = list.FirstOrDefault(x => x.Id == entity.Id);
                list.Remove(item);
                list.Add(entity);
                _memoryCache.Set(key, list);
                await _jsRuntime.InvokeVoidAsync("appHelpers.cacheHelper.saveDataToCache", PwaCacheName, key, JsonSerializer.Serialize(list));
            }
            return result;
        }
        //método para vaciar la caché de una determinada key
        public void ClearCache<T>()
        {
            var key = typeof(T).Name;
            _memoryCache.Remove(key);
            _jsRuntime.InvokeVoidAsync("appHelpers.cacheHelper.clearDataFromCache", PwaCacheName, key);
        }
        //método para vaciar toda la caché
        public void ClearAllCache()
        {
            _memoryCache.Dispose();
        }
        //método para obtener un dato de la caché a partir de su clave
        public T GetCache<T>(string key) where T : class, IEntityWithId
        {
            if (_memoryCache.TryGetValue(key, out T cachedObject))
            {
                return cachedObject;
            }
            return null;
        }
        //método para agregar un dato a la caché a partir de su clave
        public void SetCache<T>(string key, T entity) where T : class, IEntityWithId
        {
            _memoryCache.Set(key, entity);
        }

    }
}
