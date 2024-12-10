using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoBack.DataContext;
using InstitutoServices.Models.MesasExamenes;

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
            //attach the related entities
            _context.Attach(inscripcionExamen.Alumno);
            _context.Attach(inscripcionExamen.Carrera);
            _context.Attach(inscripcionExamen.TurnoExamen);
            foreach (var detalle in inscripcionExamen.detallesInscripcionesExamenes)
            {
                _context.Attach(detalle.Materia);
            }
            _context.inscripcionesExamenes.Add(inscripcionExamen);
            await _context.SaveChangesAsync();

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
