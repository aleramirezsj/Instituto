using InstitutoServices.Class;
using InstitutoServices.Interfaces;
using InstitutoServices.Models;
using InstitutoServices.Util;
using System.Linq.Expressions;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using static System.Net.WebRequestMethods;


namespace InstitutoServices.Services.Commons
{
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly HttpClient client;
        protected readonly JsonSerializerOptions options;
        protected readonly string _endpoint;

        public GenericService(HttpClient client)
        {
            this.client = client;
            this.options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            this._endpoint= ApiEndpoints.GetEndpoint(typeof(T).Name);
        }

        public GenericService()
        {
            this.client = new HttpClient();
            this.options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            string branch = "dev";
            string urlApi;
            if (branch == "master")
                urlApi = "https://api.isp20.edu.ar/api/";
            else
                urlApi = "https://api2.isp20.edu.ar/api/";
                //urlApi = "https://localhost:7202/api/";

            //string urlApi;
            //if (Properties.Resources.Remoto == "false")
            //{
            //    urlApi = Properties.Resources.UrlApiLocal;
            //}
            //else
            //{
            //    urlApi = Properties.Resources.UrlApiRemoto;
            //}

            this._endpoint = urlApi+ApiEndpoints.GetEndpoint(typeof(T).Name);
        }

        public async Task<List<T>?> GetAllAsync()
        {
            var response = await client.GetAsync(_endpoint);
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<T>>(content, options); 
        }

        public async Task<List<T>?> GetWithFilterAsync(Expression<Func<T, bool>> filter)
        {
            var listFilter = ExpressionToFilterDTOConverter.Convert(filter);
            var json = JsonSerializer.Serialize(listFilter);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{_endpoint}/filter", content);
            var responseContent = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(responseContent?.ToString());
            }
            return JsonSerializer.Deserialize<List<T>>(responseContent, options);
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            var response = await client.GetAsync($"{_endpoint}/{id}");
            var content= await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return  System.Text.Json.JsonSerializer.Deserialize<T>(content,options);
        }

        public async Task<T?> AddAsync(T? entity)
        {
            var response=await client.PostAsJsonAsync(_endpoint,entity);
            var content=await response.Content.ReadAsStreamAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString()); 
            }
            return System.Text.Json.JsonSerializer.Deserialize<T>(content, options);
        }  
        
        public async Task<bool> UpdateAsync(T? entity)
        {
            var idValue = entity.GetType().GetProperty("Id").GetValue(entity);

            var response =await client.PutAsJsonAsync($"{_endpoint}/{idValue}",entity);
            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response?.ToString());
            }
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var response=await client.DeleteAsync($"{_endpoint}/{id}");
            if(!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(response.ToString());
            }
            return response.IsSuccessStatusCode;
        }
    }

}
