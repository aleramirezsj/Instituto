using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoBack.DataContext;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.Inscripciones;

namespace InstitutoBack.Controllers.Horarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPeriodosHorariosController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiPeriodosHorariosController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiPeriodosHorarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeriodoHorario>>> Getperiodoshorarios()
        {
            return await _context.periodoshorarios.Include(p=>p.CicloLectivo).ToListAsync();
        }

        // GET: api/ApiPeriodosHorarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeriodoHorario>> GetPeriodoHorario(int id)
        {
            var periodoHorario = await _context.periodoshorarios.Include(p => p.CicloLectivo).Where(p=>p.Id.Equals(id)).FirstOrDefaultAsync();

            if (periodoHorario == null)
            {
                return NotFound();
            }

            return periodoHorario;
        }

        // PUT: api/ApiPeriodosHorarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeriodoHorario(int id, PeriodoHorario periodoHorario)
        {
            //atach de CicloLectivo
            _context.Attach(periodoHorario.CicloLectivo);
            if (id != periodoHorario.Id)
            {
                return BadRequest();
            }
            if (periodoHorario.Actual)
            {
                var periodos = _context.periodoshorarios.Where(x => x.Actual && x.Id != periodoHorario.Id).ToList();
                foreach (var item in periodos)
                {
                    item.Actual = false;
                    _context.periodoshorarios.Update(item);
                }
            }
            _context.Entry(periodoHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodoHorarioExists(id))
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

        // POST: api/ApiPeriodosHorarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PeriodoHorario>> PostPeriodoHorario(PeriodoHorario periodoHorario)
        {
            _context.Attach(periodoHorario.CicloLectivo);
            if (periodoHorario.Actual)
            {
                var periodos = _context.periodoshorarios.Where(x => x.Actual && x.Id != periodoHorario.Id).ToList();
                foreach (var item in periodos)
                {
                    item.Actual = false;
                    _context.periodoshorarios.Update(item);
                }
            }
            _context.periodoshorarios.Add(periodoHorario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeriodoHorario", new { id = periodoHorario.Id }, periodoHorario);
        }

        // DELETE: api/ApiPeriodosHorarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriodoHorario(int id)
        {
            var periodoHorario = await _context.periodoshorarios.FindAsync(id);
            if (periodoHorario == null)
            {
                return NotFound();
            }
            periodoHorario.Eliminado = true;
            _context.Entry(periodoHorario).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeriodoHorarioExists(int id)
        {
            return _context.periodoshorarios.Any(e => e.Id == id);
        }
    }
}
