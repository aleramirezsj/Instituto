using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.MesasExamenes;
using InstitutoServices.Services.Commons;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace InstitutoTest
{
    public class TestGenericWebApi
    {
        private readonly IMemoryCacheService _memoryCacheService;

        public TestGenericWebApi()
        {
            // Configurar IMemoryCache
            var memoryCacheOptions = new MemoryCacheOptions();
            var memoryCache = new MemoryCache(memoryCacheOptions);

            // Instanciar MemoryCacheService
            _memoryCacheService = new MemoryCacheService(memoryCache);
        }
        [Fact]
        public async void GetWithFiltersInGenericLeticiaMariaPerondini()
        {
            GenericService<Alumno> service = new GenericService<Alumno>();
            var result = await service.GetWithFilterAsync(filter: a=>a.ApellidoNombre.Contains("Leticia María Perondini"));
            Assert.Equal(1, result.Count);
        }
        [Fact]
        public async void GetWithFiltersInMemoryCacheLeticiaMariaPerondini()
        {
            var stopwatch = Stopwatch.StartNew();

            var result = await _memoryCacheService.GetWithFilterCacheAsync<Alumno>(filter: a => a.ApellidoNombre.Contains("Leticia María Perondini"));

            stopwatch.Stop();
            var elapsedMilliseconds = stopwatch.ElapsedMilliseconds;

            Debug.WriteLine($"Tiempo de retorno de los datos: {elapsedMilliseconds} ms");
            stopwatch = Stopwatch.StartNew();

            var result2 = await _memoryCacheService.GetWithFilterCacheAsync<Alumno>(filter: a => a.ApellidoNombre.Contains("Leticia María Perondini"));

            stopwatch.Stop();
            var elapsedMilliseconds2 = stopwatch.ElapsedMilliseconds;

            Debug.WriteLine($"segunda ejecucion: retorno de los datos: {elapsedMilliseconds2} ms");

            Assert.Equal(1, result.Count);
        }
        [Fact]
        public async void GetWithFiltersInMemoryCacheAniosCarreraForTSDS()
        {

            var result = await _memoryCacheService.GetWithFilterCacheAsync<AnioCarrera>(filter: a => a.CarreraId.Equals(1));

            Assert.Equal(3, result.Count);
        }

        [Fact]
        public async void GetWithFiltersInMemoryCacheAniosCarreraForProfInicial()
        {

            var result = await _memoryCacheService.GetWithFilterCacheAsync<AnioCarrera>(filter: a =>  a.Carrera.Nombre.Contains("Inicial"));

            Assert.Equal(4, result.Count);
        }
        [Fact]
        public async void GetWithFiltersInMemoryCacheAniosCarreraThreeCriteria()
        {

            var result = await _memoryCacheService.GetWithFilterCacheAsync<AnioCarrera>(filter: a => a.Carrera.Nombre.Contains("Inicial")&&a.Nombre.Contains("3")||a.CarreraId.Equals(2));

            Assert.Equal(4, result.Count);
        }
        
        // pruebo GetWithFilterCacheAsync en la entidad Aula
        [Fact]
        public async void GetWithFiltersInMemoryCacheAula()
        {

            var result = await _memoryCacheService.GetWithFilterCacheAsync<Aula>(filter: a => a.Nombre.Contains("Aula 11"));

            Assert.Equal(1, result.Count);
        }
       
        // pruebo GetWithFilterCacheAsync en la entidad Carrera
        [Fact]
        public async void GetWithFiltersInMemoryCacheCarrera()
        {

            var result = await _memoryCacheService.GetWithFilterCacheAsync<Carrera>(filter: a => a.Nombre.Contains("Inicial"));

            Assert.Equal(1, result.Count);
        }
        
        // pruebo GetWithFilterCacheAsync en la entidad Docente
        [Fact]
        public async void GetWithFiltersInMemoryCacheDocente()
        {

            var result = await _memoryCacheService.GetWithFilterCacheAsync<Docente>(filter: a => a.Nombre.Contains("Ruiz"));

            Assert.Equal(1, result.Count);
        }
        
        // pruebo GetWithFilterCacheAsync en la entidad InscriptoCarrera
        [Fact]
        public async void GetWithFiltersInMemoryCacheInscriptosCarrera()
        {

            var result = await _memoryCacheService.GetWithFilterCacheAsync<InscriptoCarrera>(filter: a => a.AlumnoId==24);

            Assert.Equal(2, result.Count);
        }
        
        // pruebo GetWithFilterCacheAsync en la entidad JefeSeccion
        [Fact]
        public async void GetWithFiltersInMemoryCacheJefaturaSeccion()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<JefaturaSeccion>(filter: a => a.DocenteId.Equals(76));
            Assert.Equal(1, result.Count);
        }

        // pruebo GetWithFilterCacheAsync en la entidad Materias
        [Fact]
        public async void GetWithFiltersInMemoryCacheMaterias()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<Materia>(filter: a => a.Nombre.Contains("Matemática"));
            Assert.Equal(11, result.Count);
        }

        // pruebo GetWithFilterCacheAsync en la entidad Usuarios
        [Fact]
        public async void GetWithFiltersInMemoryCacheUsuarios()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<Usuario>(filter: a => a.Nombre.Contains("Paola Arnolfo"));
            Assert.Equal(1, result.Count);
        }

        // pruebo GetWithFilterCacheAsync en la entidad DetallesHorarios
        [Fact]
        public async void GetWithFiltersInMemoryCacheDetallesHorarios()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<DetalleHorario>(filter: a => a.AulaId.Equals(13));
            Assert.Equal(4, result.Count);
        }

        // pruebo GetWithFilterCacheAsync en la entidad DetallesHorarios en propiedades relacionadas
        [Fact]
        public async void GetWithFiltersInMemoryCacheDetallesHorariosWithRelatedProperties()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<DetalleHorario>(filter: a => a.Horario.Materia.Nombre.Contains("Talento"));
            Assert.Equal(4, result.Count);
        }

        // pruebo GetWithFilterCacheAsync en la entidad DetallesHorarios en propiedades relacionadas combinando 2 criterios
        // usando un filtro sobre enums
        [Fact]
        public async void GetWithFiltersInMemoryCacheDetallesHorariosWithRelatedPropertiesCombinedTwoCriteria()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<DetalleHorario>(filter: a => a.Horario.Materia.Nombre.Contains("Talento") && a.Dia.Equals(2));
            Assert.Equal(2, result.Count);
        }

        // pruebo GetWithFilterCacheAsync en la entidad Horarios 
        [Fact]
        public async void GetWithFiltersInMemoryCacheHorarios()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<Horario>(filter: a => a.Materia.Nombre.Contains("Gestion"));
            Assert.Equal(12, result.Count);
        }

        // pruebo GetWithFilterCacheAsync en la entidad Horas 
        [Fact]
        public async void GetWithFiltersInMemoryCacheHoras()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<Hora>(filter: a => a.Desde.ToString().Contains("08:00:00"));
            Assert.Equal(1, result.Count);
        }

        //pruebo GetWithFilterCacheAsync en la entidad IntegranteHorario(pruebo mis horarios que son 8 desde la tabla integrantes
        [Fact]
        public async void GetWithFiltersInMemoryCacheIntegranteHorario()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<IntegranteHorario>(filter: a => a.Docente.Nombre.Contains("Ramirez"));
            Assert.Equal(8, result.Count);
        }

        //pruebo GetWithFilterCacheAsync en la entidad PeriodoHorario
        [Fact]
        public async void GetWithFiltersInMemoryCachePeriodoHorario()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<PeriodoHorario>(filter: a => a.Nombre.Contains("2025"));
            Assert.Equal(1, result.Count);
        }

        //pruebo GetWithFilterCacheAsync en la entidad CicloLectivo
        [Fact]
        public async void GetWithFiltersInMemoryCacheCicloLectivo()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<CicloLectivo>(filter: a => a.Nombre.Contains("2025"));
            Assert.Equal(1, result.Count);
        }

        //pruebo GetWithFilterCacheAsync en la entidad PeriodosInscripciones
        [Fact]
        public async void GetWithFiltersInMemoryCachePeriodosInscripciones()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<PeriodoInscripcion>(filter: a => a.Nombre.Contains("2024"));
            Assert.Equal(2, result.Count);
        }

        //pruebo GetWithFilterCacheAsync en la entidad DetallesInscripcionesExamenes
        [Fact]
        public async void GetWithFiltersInMemoryCacheDetallesInscripcionesExamenes()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<DetalleInscripcionExamen>(filter: a => a.Materia.Nombre.Contains("Talento"));
            Assert.Equal(15, result.Count);
        }

        //pruebo GetWithFilterCacheAsync en la entidad MesasExamenes
        [Fact]
        public async void GetWithFiltersInMemoryCacheMesasExamenes()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<MesaExamen>(filter: a => a.Materia.Nombre.Contains("Talento"));
            Assert.Equal(2, result.Count);
        }

        //pruebo GetWithFilterCacheAsync en la entidad DetallesMesaExamen
        [Fact]
        public async void GetWithFiltersInMemoryCacheDetallesMesaExamen()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<DetalleMesaExamen>(filter: a => a.MesaExamen.Materia.Nombre.Contains("Talento"));
            Assert.Equal(8, result.Count);
        }

        //pruebo GetWithFilterCacheAsync en la entidad InscripcionExamen
        [Fact]
        public async void GetWithFiltersInMemoryCacheInscripcionExamen()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<InscripcionExamen>(filter: a => a.Fecha.ToString().Contains("2024-12-23"));
            Assert.Equal(68, result.Count);
        }

        //pruebo GetWithFilterCacheAsync en la entidad TurnoExamen
        [Fact]
        public async void GetWithFiltersInMemoryCacheTurnoExamen()
        {
            var result = await _memoryCacheService.GetWithFilterCacheAsync<TurnoExamen>(filter: a => a.Nombre.Contains("2025"));
            Assert.Equal(1, result.Count);
        }
    }
}