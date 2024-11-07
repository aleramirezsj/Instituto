using InstitutoDesktop.Util;
using InstitutoServices.Interfaces;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace InstitutoDesktop.Services
{
    public class MemoryCacheServiceWinForms : MemoryCacheService
    {
        public MemoryCacheServiceWinForms(IMemoryCache memoryCache) : base(memoryCache)
        {
           
        }
        public override async Task<List<T>> GetAllCacheAsync<T>() where T : class
        {
            //ShowInActivity.Show($"Descargando/actualizando la lista de {key}");
            var retorno= await base.GetAllCacheAsync<T>();
            //ShowInActivity.Hide();
            return retorno;
        }
        public override async Task<bool> DeleteCacheAsync<T>(int id) where T : class
        {
            var key = typeof(T).Name;
            ShowInActivity.Show($"Eliminando un registro del tipo {key}");
            var retorno= await base.DeleteCacheAsync<T>(id);
            ShowInActivity.Hide();
            return retorno;
        }
        public override async Task<T> AddCacheAsync<T>(T entity) where T : class
        {
            var key = typeof(T).Name;
            ShowInActivity.Show($"Agregando un registro del tipo {key}");
            var retorno= await base.AddCacheAsync<T>(entity);
            ShowInActivity.Hide();
            return retorno;
        }
        public override async Task<bool> UpdateCacheAsync<T>(T entity) where T : class
        {
            var key = typeof(T).Name;
            ShowInActivity.Show($"Actualizando un registro del tipo {key}");
            var retorno = await base.UpdateCacheAsync<T>(entity);
            ShowInActivity.Hide();
            return retorno;
        }
    }
}
