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
                .Include(i=>i.TurnoExamen).ToListAsync();
        }

        // GET: api/ApiInscripcionesExamenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InscripcionExamen>> GetInscripcionExamen(int id)
        {
            var inscripcionExamen = await _context.inscripcionesExamenes.Include(i => i.Alumno)
                .Include(i => i.Carrera)
                .Include(i => i.TurnoExamen).FirstOrDefaultAsync(i=>i.Id.Equals(id));

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
            _context.Attach(inscripcionExamen.Alumno);
            _context.Attach(inscripcionExamen.Carrera);
            _context.Attach(inscripcionExamen.TurnoExamen);
            foreach (var detalle in inscripcionExamen.detallesInscripcionesExamenes)
            {
                _context.Attach(detalle.Materia);
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
                _context.Attach(inscripcionExamen.Carrera);
                foreach (var insc_carrera in inscripcionExamen.Alumno.InscripcionesACarreras)
                {
                    var AttachCarreraExist = _context.Set<Carrera>().Local.FirstOrDefault(entry => entry.Id.Equals(insc_carrera.Carrera.Id));
                    if (AttachCarreraExist == null)
                        _context.Attach(insc_carrera.Carrera);
                    else
                        insc_carrera.Carrera = AttachCarreraExist;
                }
                //if (!_context.Entry(inscripcionExamen.Carrera).IsKeySet) 
                 
                //inscripcionExamen.Carrera = null;
                _context.Attach(inscripcionExamen.Alumno);

                //if (!_context.Entry(inscripcionExamen.TurnoExamen.CicloLectivo).IsKeySet)
                _context.Attach(inscripcionExamen.TurnoExamen.CicloLectivo);

                //if (!_context.Entry(inscripcionExamen.TurnoExamen).IsKeySet) 
                _context.Attach(inscripcionExamen.TurnoExamen);
                
                
                

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
            var inscripcionExamen = await _context.inscripcionesExamenes.FindAsync(id);
            if (inscripcionExamen == null)
            {
                return NotFound();
            }
            inscripcionExamen.Eliminado = true;
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
