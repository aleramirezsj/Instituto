using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoServices.Models;
using InstitutoBack.DataContext;
using InstitutoServices.Models.MesasExamenes;
using InstitutoServices.Class;

namespace InstitutoBack.Controllers.MesasExamenes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiTurnosExamenesController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiTurnosExamenesController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiTurnosExamenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TurnoExamen>>> Getturnosexamenes()
        {
            return await _context.turnosexamenes.Include(t=>t.CicloLectivo).ToListAsync();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<TurnoExamen>>> Getturnosexamenes([FromBody] List<FilterDTO> filters)
        {
            var filterExpression = BuilderPredicate.GetExpression<TurnoExamen>(filters);

            if (filterExpression == null)
            {
                return BadRequest("Invalid filter expression.");
            }
            return await _context.turnosexamenes.Include(t => t.CicloLectivo).Where(filterExpression).AsNoTracking().ToListAsync();
        }

        // GET: api/ApiTurnosExamenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TurnoExamen>> GetTurnoExamen(int id)
        {
            var turnoExamen = await _context.turnosexamenes.FindAsync(id);

            if (turnoExamen == null)
            {
                return NotFound();
            }

            return turnoExamen;
        }

        // PUT: api/ApiTurnosExamenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTurnoExamen(int id, TurnoExamen turnoExamen)
        {
            if (id != turnoExamen.Id)
            {
                return BadRequest();
            }
            //attach ciclos lectivos
            _context.Attach(turnoExamen.CicloLectivo);
            if (turnoExamen.Actual)
            {
                var turnos = _context.turnosexamenes.Where(x => x.Actual&&x.Id!=turnoExamen.Id).ToList();
                foreach (var item in turnos)
                {
                    item.Actual = false;
                    _context.turnosexamenes.Update(item);
                }
            }

            _context.Entry(turnoExamen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TurnoExamenExists(id))
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

        // POST: api/ApiTurnosExamenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TurnoExamen>> PostTurnoExamen(TurnoExamen turnoExamen)
        {
            _context.Attach(turnoExamen.CicloLectivo);
            if (turnoExamen.Actual)
            {
                var turnos = _context.turnosexamenes.Where(x => x.Actual && x.Id != turnoExamen.Id).ToList();
                foreach (var item in turnos)
                {
                    item.Actual = false;
                    _context.turnosexamenes.Update(item);
                }
            }

            _context.turnosexamenes.Add(turnoExamen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTurnoExamen", new { id = turnoExamen.Id }, turnoExamen);
        }

        // DELETE: api/ApiTurnosExamenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTurnoExamen(int id)
        {
            var turnoExamen = await _context.turnosexamenes.FindAsync(id);
            if (turnoExamen == null)
            {
                return NotFound();
            }

            turnoExamen.Eliminado = true;
            _context.turnosexamenes.Update(turnoExamen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TurnoExamenExists(int id)
        {
            return _context.turnosexamenes.Any(e => e.Id == id);
        }
    }
}
