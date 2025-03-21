using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoServices.Models;
using InstitutoBack.DataContext;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Class;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoBack.Controllers.Inscripciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiInscripcionesController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiInscripcionesController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiInscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscripcion>>> Getinscripciones()
        {
            return await _context.inscripciones
                .Include(i => i.Carrera)
                .Include(i => i.Alumno)
                .Include(i=>i.PeriodoInscripcion)
                .Include(i=>i.detallesInscripciones)
                    .ThenInclude(d=>d.Materia)
                    .ThenInclude(m=>m.AnioCarrera).AsNoTracking()
                    .ToListAsync();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<Inscripcion>>> Getinscripciones([FromBody] List<FilterDTO> filters)
        {
            var filterExpression = BuilderPredicate.GetExpression<Inscripcion>(filters);

            if (filterExpression == null)
            {
                return BadRequest("Invalid filter expression.");
            }
            return await _context.inscripciones
                .Include(i => i.Carrera)
                .Include(i => i.Alumno)
                .Include(i=>i.PeriodoInscripcion)
                .Include(i=>i.detallesInscripciones)
                    .ThenInclude(d=>d.Materia)
                    .ThenInclude(m=>m.AnioCarrera).Where(filterExpression).AsNoTracking().ToListAsync();
        }


        // GET: api/ApiInscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripcion>> GetInscripcion(int id)
        {
            var inscripcion = await _context.inscripciones
                .Include(i => i.Carrera)
                .Include(i => i.Alumno)
                .Include(i => i.PeriodoInscripcion)
                .Include(i => i.detallesInscripciones)
                    .ThenInclude(d => d.Materia)
                    .ThenInclude(m => m.AnioCarrera).AsNoTracking()
                    .FirstOrDefaultAsync(i => i.Id.Equals(id));

            if (inscripcion == null)
            {
                return NotFound();
            }

            return inscripcion;
        }

        // PUT: api/ApiInscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcion(int id, Inscripcion inscripcion)
        {
            if (inscripcion.Carrera != null) _context.Attach(inscripcion.Carrera);
            if (inscripcion.PeriodoInscripcion != null) _context.Attach(inscripcion.PeriodoInscripcion);
            if (inscripcion.PeriodoInscripcion.CicloLectivo != null) _context.Attach(inscripcion.PeriodoInscripcion.CicloLectivo);

            foreach (var insc_carrera in inscripcion.Alumno.InscripcionesACarreras)
            {
                var AttachCarreraExist = _context.Set<Carrera>().Local.FirstOrDefault(entry => entry.Id.Equals(insc_carrera.Carrera.Id));
                if (AttachCarreraExist == null)
                    _context.Attach(insc_carrera.Carrera);
                else
                    insc_carrera.Carrera = AttachCarreraExist;
            }
            if (inscripcion.Alumno != null) _context.Attach(inscripcion.Alumno);

            foreach (var detalle in inscripcion.detallesInscripciones)
            {
                //detalle.Materia.AnioCarrera = null;
                var AttachAnioExist = _context.Set<AnioCarrera>().Local.FirstOrDefault(entry => entry.Id.Equals(detalle.Materia.AnioCarrera.Id));
                var AttachCarreraExist = _context.Set<Carrera>().Local.FirstOrDefault(entry => entry.Id.Equals(detalle.Materia.AnioCarrera.Carrera.Id));
                if (AttachCarreraExist == null)
                    _context.Attach(detalle.Materia.AnioCarrera.Carrera);
                else
                    detalle.Materia.AnioCarrera.Carrera = AttachCarreraExist;
                if (AttachAnioExist == null)
                    _context.Attach(detalle.Materia.AnioCarrera);
                else
                    detalle.Materia.AnioCarrera = AttachAnioExist;

                _context.Attach(detalle.Materia);

            }

            //busco los detalles existentes para poder encontrar los eliminados
            var detallesExistentes = _context.detallesinscripciones.Where(d => d.InscripcionId.Equals(inscripcion.Id)).AsNoTracking().ToList();
            //busco los detalles que se eliminaron
            var detallesEliminados = detallesExistentes.Where(d => !inscripcion.detallesInscripciones.Any(di => di.Id == d.Id)).ToList();
            foreach (var detalle in inscripcion.detallesInscripciones)
            {
                if (detalle.Id == 0)
                {
                    _context.detallesinscripciones.Add(detalle);
                }
                else
                {
                    _context.Entry(detalle).State = EntityState.Modified;
                }
            }
            foreach (var detalle in detallesEliminados)
            {
                _context.detallesinscripciones.Remove(detalle);
            }

            if (id != inscripcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(inscripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ApiInscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inscripcion>> PostInscripcion(Inscripcion inscripcion)
        {
            try
            {
                if (inscripcion.Carrera != null) _context.Attach(inscripcion.Carrera);
                if (inscripcion.PeriodoInscripcion != null) _context.Attach(inscripcion.PeriodoInscripcion);
                if (inscripcion.PeriodoInscripcion.CicloLectivo != null) _context.Attach(inscripcion.PeriodoInscripcion.CicloLectivo);

                foreach (var insc_carrera in inscripcion.Alumno.InscripcionesACarreras)
                {
                    var AttachCarreraExist = _context.Set<Carrera>().Local.FirstOrDefault(entry => entry.Id.Equals(insc_carrera.Carrera.Id));
                    if (AttachCarreraExist == null)
                        _context.Attach(insc_carrera.Carrera);
                    else
                        insc_carrera.Carrera = AttachCarreraExist;
                }

                foreach (var detalle in inscripcion.detallesInscripciones)
                {
                    //detalle.Materia.AnioCarrera = null;
                    var AttachAnioExist = _context.Set<AnioCarrera>().Local.FirstOrDefault(entry => entry.Id.Equals(detalle.Materia.AnioCarrera.Id));
                    var AttachCarreraExist = _context.Set<Carrera>().Local.FirstOrDefault(entry => entry.Id.Equals(detalle.Materia.AnioCarrera.Carrera.Id));
                    if (AttachCarreraExist == null)
                        _context.Attach(detalle.Materia.AnioCarrera.Carrera);
                    else
                        detalle.Materia.AnioCarrera.Carrera = AttachCarreraExist;
                    if (AttachAnioExist == null)
                        _context.Attach(detalle.Materia.AnioCarrera);
                    else
                        detalle.Materia.AnioCarrera = AttachAnioExist;

                    _context.Attach(detalle.Materia);

                }
                if (inscripcion.Alumno != null) _context.Attach(inscripcion.Alumno);

                _context.inscripcionesExamenes.Add(inscripcion);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al adjuntar entidades relacionadas o guardar la inscripción de examen.", ex);
            }

            return CreatedAtAction("GetInscripcionExamen", new { id = inscripcion.Id }, inscripcion);
        }

        // DELETE: api/ApiInscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcion(int id)
        {
            var inscripcion = await _context.inscripciones.Include(i => i.Alumno)
                .Include(i => i.Carrera)
                .Include(i => i.PeriodoInscripcion)
                .Include(i => i.detallesInscripciones)
                    .ThenInclude(d => d.Materia).ThenInclude(m => m.AnioCarreraId)
                    .FirstOrDefaultAsync(i => i.Id.Equals(id));
            if (inscripcion == null)
            {
                return NotFound();
            }
            inscripcion.Eliminado = true;
            foreach (var detalle in inscripcion.detallesInscripciones)
            {
                _context.detallesinscripciones.Remove(detalle);
            }
            _context.inscripciones.Update(inscripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscripcionExists(int id)
        {
            return _context.inscripciones.Any(e => e.Id == id);
        }
    }
}
