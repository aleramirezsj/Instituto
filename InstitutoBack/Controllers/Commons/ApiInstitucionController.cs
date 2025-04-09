using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoBack.DataContext;
using InstitutoServices.Models.Commons;
using InstitutoServices.Class;

namespace InstitutoBack.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiInstitucionesController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiInstitucionesController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiAulas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Institucion>>> Getinstituciones()
        {
            return await _context.instituciones.ToListAsync();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<Institucion>>> Getinstituciones([FromBody] List<FilterDTO> filters)
        {
            var filterExpression = BuilderPredicate.GetExpression<Institucion>(filters);

            if (filterExpression == null)
            {
                return BadRequest("Invalid filter expression.");
            }
            return await _context.instituciones.Where(filterExpression).AsNoTracking().ToListAsync();
        }

        // GET: api/ApiInstituciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Institucion>> GetInstitucion(int id)
        {
            var institucion = await _context.instituciones.FindAsync(id);

            if (institucion == null)
            {
                return NotFound();
            }

            return institucion;
        }

        // PUT: api/ApiInstituciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstitucion(int id, Institucion institucion)
        {
            if (id != institucion.Id)
            {
                return BadRequest();
            }

            _context.Entry(institucion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstitucionExists(id))
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

        // POST: api/ApiInstituciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Institucion>> PostInstitucion(Institucion institucion)
        {
            _context.instituciones.Add(institucion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstitucion", new { id = institucion.Id }, institucion);
        }

        // DELETE: api/ApiInstituciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstitucion(int id)
        {
            var institucion = await _context.instituciones.FindAsync(id);
            if (institucion == null)
            {
                return NotFound();
            }

            _context.instituciones.Remove(institucion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstitucionExists(int id)
        {
            return _context.instituciones.Any(e => e.Id == id);
        }
    }
}
