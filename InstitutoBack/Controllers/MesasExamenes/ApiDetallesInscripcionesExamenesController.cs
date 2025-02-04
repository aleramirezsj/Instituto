using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoBack.DataContext;
using InstitutoServices.Models.MesasExamenes;
using InstitutoServices.Class;

namespace InstitutoBack.Controllers.MesasExamenes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDetallesInscripcionesExamenesController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiDetallesInscripcionesExamenesController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiDetallesInscripcionesExamenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleInscripcionExamen>>> GetdetallesInscripcionesExamenes()
        {
            return await _context.detallesInscripcionesExamenes.Include(d=>d.InscripcionExamen).ThenInclude(i=>i.Alumno)
                .Include(d => d.InscripcionExamen).ThenInclude(i => i.Carrera)
                .Include(d => d.InscripcionExamen).ThenInclude(i => i.TurnoExamen)
                .Include(d=>d.Materia).ThenInclude(d=>d.AnioCarrera).AsNoTracking().ToListAsync();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<DetalleInscripcionExamen>>> GetdetallesInscripcionesExamenes([FromBody] List<FilterDTO> filters)
        {
            var filterExpression = BuilderPredicate.GetExpression<DetalleInscripcionExamen>(filters);

            if (filterExpression == null)
            {
                return BadRequest("Invalid filter expression.");
            }
            return await _context.detallesInscripcionesExamenes
                .Include(d => d.InscripcionExamen).ThenInclude(i => i.Alumno)
                .Include(d => d.InscripcionExamen).ThenInclude(i => i.Carrera)
                .Include(d => d.InscripcionExamen).ThenInclude(i => i.TurnoExamen)
                .Include(d => d.Materia).ThenInclude(d => d.AnioCarrera)
                .Where(filterExpression).AsNoTracking().ToListAsync();
        }


        // GET: api/ApiDetallesInscripcionesExamenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleInscripcionExamen>> GetDetalleInscripcionExamen(int id)
        {
            var detalleInscripcionExamen = await _context.detallesInscripcionesExamenes
                .Include(d => d.InscripcionExamen).ThenInclude(i => i.Alumno)
                .Include(d => d.InscripcionExamen).ThenInclude(i => i.Carrera)
                .Include(d => d.InscripcionExamen).ThenInclude(i => i.TurnoExamen)
                .Include(d => d.Materia).ThenInclude(d => d.AnioCarrera)
                .FirstOrDefaultAsync(d=>d.Id.Equals(id));

            if (detalleInscripcionExamen == null)
            {
                return NotFound();
            }

            return detalleInscripcionExamen;
        }

        // PUT: api/ApiDetallesInscripcionesExamenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleInscripcionExamen(int id, DetalleInscripcionExamen detalleInscripcionExamen)
        {
            if (id != detalleInscripcionExamen.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleInscripcionExamen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleInscripcionExamenExists(id))
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

        // POST: api/ApiDetallesInscripcionesExamenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleInscripcionExamen>> PostDetalleInscripcionExamen(DetalleInscripcionExamen detalleInscripcionExamen)
        {
            _context.detallesInscripcionesExamenes.Add(detalleInscripcionExamen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleInscripcionExamen", new { id = detalleInscripcionExamen.Id }, detalleInscripcionExamen);
        }

        // DELETE: api/ApiDetallesInscripcionesExamenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleInscripcionExamen(int id)
        {
            var detalleInscripcionExamen = await _context.detallesInscripcionesExamenes.FindAsync(id);
            if (detalleInscripcionExamen == null)
            {
                return NotFound();
            }

            _context.detallesInscripcionesExamenes.Remove(detalleInscripcionExamen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleInscripcionExamenExists(int id)
        {
            return _context.detallesInscripcionesExamenes.Any(e => e.Id == id);
        }
    }
}
