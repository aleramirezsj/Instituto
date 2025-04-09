using InstitutoServices.Class;
using InstitutoServices.Interfaces;
using System.Net.Http;
using System.Net;
using System.Text.Json;
using InstitutoServices.Interfaces.Inscripciones;
using InstitutoServices.Services.Commons;
using InstitutoServices.Models.Inscripciones;

namespace InstitutoServices.Services.Inscripciones
{
    public class DetalleInscripcionService : GenericService<DetalleInscripcion>, IDetalleInscripcionService
    {


        public DetalleInscripcionService(HttpClient client) : base(client)
        {

        }

        public DetalleInscripcionService()
        {
        }

        public async Task<List<DetalleInscripcion>?> GetByInscripcionAsync(int? idInscripcion)
        {
            var response = await client.GetAsync($"{_endpoint}?idInscripcion={idInscripcion}");
            var content = await response.Content.ReadAsStringAsync();
            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException(content?.ToString());
            }
            return JsonSerializer.Deserialize<List<DetalleInscripcion>>(content, options); ;
        }

        public async Task<bool> CheckDuplicadoDetalleInscripcionAsync(int? idDetalle, int? idInscripcion, int? idMateria)
        {
            var response = await client.GetAsync($"{_endpoint}/checkduplicado?idDetalle={idDetalle}&idInscripcion={idInscripcion}&idMateria={idMateria}");
            return response.StatusCode == HttpStatusCode.Conflict;

        }
    }
}
