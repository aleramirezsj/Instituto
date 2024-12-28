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
using InstitutoServices.Models.MesasExamenes;
using InstitutoServices.Class;

namespace InstitutoBack.Controllers.Inscripciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiCiclosLectivosController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiCiclosLectivosController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiAniosLectivos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CicloLectivo>>> Getacicloslectivos()
        {
            return await _context.cicloslectivos.ToListAsync();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<CicloLectivo>>> Getcicloslectivos([FromBody] List<FilterDTO> filters)
        {
            var filterExpression = BuilderPredicate.GetExpression<CicloLectivo>(filters);

            if (filterExpression == null)
            {
                return BadRequest("Invalid filter expression.");
            }
            return await _context.cicloslectivos.Where(filterExpression).AsNoTracking().ToListAsync();
        }



        // GET: api/ApiAniosLectivos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CicloLectivo>> GetCicloLectivo(int id)
        {
            var cicloLectivo = await _context.cicloslectivos.FindAsync(id);

            if (cicloLectivo == null)
            {
                return NotFound();
            }

            return cicloLectivo;
        }

        // PUT: api/ApiAniosLectivos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCicloLectivo(int id, CicloLectivo cicloLectivo)
        {
            if (id != cicloLectivo.Id)
            {
                return BadRequest();
            }
            if (cicloLectivo.Actual)
            {
                var ciclos = _context.cicloslectivos.Where(x => x.Actual&&x.Id!=cicloLectivo.Id).ToList();
                foreach (var item in ciclos)
                {
                    item.Actual = false;
                    _context.cicloslectivos.Update(item);
                }
            }

            _context.Entry(cicloLectivo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CicloLectivoExists(id))
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

        // POST: api/ApiAniosLectivos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CicloLectivo>> PostCicloLectivo(CicloLectivo cicloLectivo)
        {
            if (cicloLectivo.Actual)
            {
                var ciclos = _context.cicloslectivos.Where(x => x.Actual).ToList();
                foreach (var item in ciclos)
                {
                    item.Actual = false;
                    _context.cicloslectivos.Update(item);
                }
            }
            _context.cicloslectivos.Add(cicloLectivo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCicloLectivo", new { id = cicloLectivo.Id }, cicloLectivo);
        }

        // DELETE: api/ApiAniosLectivos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnioLectivo(int id)
        {
            var cicloLectivo = await _context.cicloslectivos.FindAsync(id);
            if (cicloLectivo == null)
            {
                return NotFound();
            }
            cicloLectivo.Eliminado = true;
            _context.cicloslectivos.Update(cicloLectivo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CicloLectivoExists(int id)
        {
            return _context.cicloslectivos.Any(e => e.Id == id);
        }
    }
}
