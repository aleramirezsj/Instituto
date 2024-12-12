using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoBack.DataContext;
using InstitutoServices.Models.MesasExamenes;
using InstitutoServices.Models.Commons;
using InstitutoServices.Models.Horarios;

namespace InstitutoBack.Controllers.MesasExamenes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiInscripcionesExamenesController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiInscripcionesExamenesController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiInscripcionesExamenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InscripcionExamen>>> GetinscripcionesExamenes()
        {
            return await _context.inscripcionesExamenes
                .Include(i=>i.Alumno)
                .Include(i=>i.Carrera)
                .Include(i=>i.TurnoExamen)
                .Include(i=>i.detallesInscripcionesExamenes)
                    .ThenInclude(d=>d.Materia).ThenInclude(m=>m.AnioCarrera)
                    .ToListAsync();
        }

        // GET: api/ApiInscripcionesExamenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscripcionExamen>> GetInscripcionExamen(int id)
        {
            var inscripcionExamen = await _context.inscripcionesExamenes.Include(i => i.Alumno)
                .Include(i => i.Carrera)
                .Include(i => i.TurnoExamen)
                .Include(i=>i.detallesInscripcionesExamenes)
                    .ThenInclude(d => d.Materia).ThenInclude(m=>m.AnioCarreraId).AsNoTracking()
                    .FirstOrDefaultAsync(i=>i.Id.Equals(id));

            if (inscripcionExamen == null)
            {
                return NotFound();
            }

            return inscripcionExamen;
        }

        // PUT: api/ApiInscripcionesExamenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcionExamen(int id, InscripcionExamen inscripcionExamen)
        {
            //attach the related entities

            if (inscripcionExamen.Carrera != null) _context.Attach(inscripcionExamen.Carrera);
            if (inscripcionExamen.TurnoExamen != null) _context.Attach(inscripcionExamen.TurnoExamen);
            if (inscripcionExamen.TurnoExamen.CicloLectivo != null) _context.Attach(inscripcionExamen.TurnoExamen.CicloLectivo);

            foreach (var insc_carrera in inscripcionExamen.Alumno.InscripcionesACarreras)
            {
                var AttachCarreraExist = _context.Set<Carrera>().Local.FirstOrDefault(entry => entry.Id.Equals(insc_carrera.Carrera.Id));
                if (AttachCarreraExist == null)
                    _context.Attach(insc_carrera.Carrera);
                else
                    insc_carrera.Carrera = AttachCarreraExist;
            }
            if (inscripcionExamen.Alumno != null) _context.Attach(inscripcionExamen.Alumno);

            foreach (var detalle in inscripcionExamen.detallesInscripcionesExamenes)
            {
                //detalle.Materia.AnioCarrera = null;
                var AttachAnioExist = _context.Set<AnioCarrera>().Local.FirstOrDefault(entry => entry.Id.Equals(detalle.Materia.AnioCarrera.Id));
                if (AttachAnioExist == null)
                    _context.Attach(detalle.Materia.AnioCarrera);
                else
                    detalle.Materia.AnioCarrera = AttachAnioExist;

                _context.Attach(detalle.Materia);

            }

            //busco los detalles existentes para poder encontrar los eliminados
            var detallesExistentes = _context.detallesInscripcionesExamenes.Where(d => d.InscripcionExamenId.Equals(inscripcionExamen.Id)).AsNoTracking().ToList();
            //busco los detalles que se eliminaron
            var detallesEliminados = detallesExistentes.Where(d => !inscripcionExamen.detallesInscripcionesExamenes.Any(di => di.Id == d.Id)).ToList();
            foreach (var detalle in inscripcionExamen.detallesInscripcionesExamenes)
            {
                if (detalle.Id == 0)
                {
                    _context.detallesInscripcionesExamenes.Add(detalle);
                }
                else
                {
                    _context.Entry(detalle).State = EntityState.Modified;
                }
            }
            foreach (var detalle in detallesEliminados)
            {
                _context.detallesInscripcionesExamenes.Remove(detalle);
            }

            if (id != inscripcionExamen.Id)
            {
                return BadRequest();
            }

            _context.Entry(inscripcionExamen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcionExamenExists(id))
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

        // POST: api/ApiInscripcionesExamenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InscripcionExamen>> PostInscripcionExamen(InscripcionExamen inscripcionExamen)
        {
            try
            {
                if (inscripcionExamen.Carrera != null) _context.Attach(inscripcionExamen.Carrera);
                if (inscripcionExamen.TurnoExamen != null) _context.Attach(inscripcionExamen.TurnoExamen);
                if (inscripcionExamen.TurnoExamen.CicloLectivo!=null) _context.Attach(inscripcionExamen.TurnoExamen.CicloLectivo);

                foreach (var insc_carrera in inscripcionExamen.Alumno.InscripcionesACarreras)
                {
                    var AttachCarreraExist = _context.Set<Carrera>().Local.FirstOrDefault(entry => entry.Id.Equals(insc_carrera.Carrera.Id));
                    if (AttachCarreraExist == null)
                        _context.Attach(insc_carrera.Carrera);
                    else
                        insc_carrera.Carrera = AttachCarreraExist;
                }

                foreach (var detalle in inscripcionExamen.detallesInscripcionesExamenes)
                {
                    //detalle.Materia.AnioCarrera = null;
                    var AttachAnioExist = _context.Set<AnioCarrera>().Local.FirstOrDefault(entry => entry.Id.Equals(detalle.Materia.AnioCarrera.Id));
                    if (AttachAnioExist == null)
                        _context.Attach(detalle.Materia.AnioCarrera);
                    else
                        detalle.Materia.AnioCarrera = AttachAnioExist;

                    _context.Attach(detalle.Materia);
                    
                }
                if (inscripcionExamen.Alumno != null) _context.Attach(inscripcionExamen.Alumno);

                _context.inscripcionesExamenes.Add(inscripcionExamen);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error al adjuntar entidades relacionadas o guardar la inscripción de examen.", ex);
            }

            return CreatedAtAction("GetInscripcionExamen", new { id = inscripcionExamen.Id }, inscripcionExamen);
        }


        // DELETE: api/ApiInscripcionesExamenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcionExamen(int id)
        {
            //este código de eliminación no se probó todavía    
            var inscripcionExamen = await _context.inscripcionesExamenes.Include(i => i.Alumno)
                .Include(i => i.Carrera)
                .Include(i => i.TurnoExamen)
                .Include(i => i.detallesInscripcionesExamenes)
                    .ThenInclude(d => d.Materia).ThenInclude(m => m.AnioCarreraId)
                    .FirstOrDefaultAsync(i => i.Id.Equals(id));
            if (inscripcionExamen == null)
            {
                return NotFound();
            }
            inscripcionExamen.Eliminado = true;
            foreach (var detalle in inscripcionExamen.detallesInscripcionesExamenes)
            {
                _context.detallesInscripcionesExamenes.Remove(detalle);
            }
            _context.inscripcionesExamenes.Update(inscripcionExamen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscripcionExamenExists(int id)
        {
            return _context.inscripcionesExamenes.Any(e => e.Id == id);
        }
    }
}
