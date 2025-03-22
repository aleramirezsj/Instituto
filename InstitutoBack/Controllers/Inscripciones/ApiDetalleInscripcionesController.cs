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

namespace InstitutoBack.Controllers.Inscripciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDetalleInscripcionesController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiDetalleInscripcionesController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiDetalleInscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleInscripcion>>> Getdetallesinscripciones([FromQuery] int? idInscripcion)
        {
            if (idInscripcion != null)
            {
                return await _context.detallesinscripciones
                    .Include(d=>d.Inscripcion).ThenInclude(i=>i.Alumno)
                    .Include(d => d.Materia).ThenInclude(m => m.AnioCarrera).Where(d => d.InscripcionId.Equals(idInscripcion)).OrderBy(d => d.Materia.AnioCarreraId).ToListAsync();
            }
            return await _context.detallesinscripciones
                .Include(d => d.Inscripcion).ThenInclude(i=>i.Alumno)
                .Include(d => d.Materia).ThenInclude(m => m.AnioCarrera)
                .OrderBy(d => d.Materia.AnioCarreraId).ThenBy(d=>d.Materia.Nombre).ToListAsync();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<DetalleInscripcion>>> Getdetallesinscripciones([FromBody] List<FilterDTO> filters)
        {
            var filterExpression = BuilderPredicate.GetExpression<DetalleInscripcion>(filters);

            if (filterExpression == null)
            {
                return BadRequest("Invalid filter expression.");
            }
            return await _context.detallesinscripciones
                .Include(d => d.Inscripcion).ThenInclude(i=>i.Alumno)    
                .Include(d => d.Materia).ThenInclude(m => m.AnioCarrera).Where(filterExpression)
                .OrderBy(d => d.Materia.AnioCarreraId).ThenBy(d=>d.Materia.Nombre).ToListAsync();
        }


        // GET: api/ApiDetalleInscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleInscripcion>> GetDetalleInscripcion(int id)
        {
            var detalleInscripcion = await _context.detallesinscripciones
                .Include(d => d.Inscripcion).ThenInclude(i => i.Alumno)
                .Include(d => d.Materia).ThenInclude(m => m.AnioCarrera)
                .FirstOrDefaultAsync(d => d.Id.Equals(id));

            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            return detalleInscripcion;
        }

        // PUT: api/ApiDetalleInscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleInscripcion(int id, DetalleInscripcion detalleInscripcion)
        {
            if (id != detalleInscripcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleInscripcion).State = EntityState.Modified;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleInscripcionExists(id))
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

        // POST: api/ApiDetalleInscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleInscripcion>> PostDetalleInscripcion(DetalleInscripcion detalleInscripcion)
        {
            _context.detallesinscripciones.Add(detalleInscripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleInscripcion", new { id = detalleInscripcion.Id }, detalleInscripcion);
        }

        // DELETE: api/ApiDetalleInscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleInscripcion(int id)
        {
            var detalleInscripcion = await _context.detallesinscripciones.FindAsync(id);
            if (detalleInscripcion == null)
            {
                return NotFound();
            }

            detalleInscripcion.Eliminado = true;
            _context.detallesinscripciones.Update(detalleInscripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleInscripcionExists(int id)
        {
            return _context.detallesinscripciones.Any(e => e.Id == id);
        }

        [HttpGet("checkduplicado")]
        public async Task<IActionResult> CheckDuplicado([FromQuery] int idDetalle, int idInscripcion, int idMateria)
        {
            bool isDuplicate;
            if (idDetalle == 0)
                isDuplicate = await _context.detallesinscripciones.AnyAsync(d => d.InscripcionId == idInscripcion && d.MateriaId == idMateria);
            else
                isDuplicate = await _context.detallesinscripciones.AnyAsync(d => d.Id != idDetalle && d.InscripcionId == idInscripcion && d.MateriaId == idMateria);

            if (isDuplicate)
            {
                return Conflict("ya está inscrito en esta materia.");
            }
            return Ok();
        }
    }
}
