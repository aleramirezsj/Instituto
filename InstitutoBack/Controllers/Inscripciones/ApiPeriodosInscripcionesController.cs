using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoBack.DataContext;
using InstitutoServices.Models.Inscripciones;
using InstitutoServices.Models.Horarios;
using InstitutoServices.Models.MesasExamenes;

namespace InstitutoBack.Controllers.Inscripciones
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiPeriodosInscripcionesController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiPeriodosInscripcionesController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiPeriodosInscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PeriodoInscripcion>>> Getperiodosinscripciones()
        {
            return await _context.periodosinscripciones.Include(p=>p.CicloLectivo).ToListAsync();
        }

        // GET: api/ApiPeriodosInscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PeriodoInscripcion>> GetPeriodoInscripcion(int id)
        {
            var periodoInscripcion = await _context.periodosinscripciones.Include(p=>p.CicloLectivo).Where(p=>p.Id.Equals(id)).FirstOrDefaultAsync();

            if (periodoInscripcion == null)
            {
                return NotFound();
            }

            return periodoInscripcion;
        }

        // PUT: api/ApiPeriodosInscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeriodoInscripcion(int id, PeriodoInscripcion periodoInscripcion)
        {
            _context.Attach(periodoInscripcion.CicloLectivo);
            if (id != periodoInscripcion.Id)
            {
                return BadRequest();
            }

            if (periodoInscripcion.InscripcionHabilitada)
            {
                var periodos = _context.periodosinscripciones.Where(x => x.InscripcionHabilitada && x.Id != periodoInscripcion.Id).ToList();
                foreach (var item in periodos)
                {
                    item.InscripcionHabilitada = false;
                    _context.periodosinscripciones.Update(item);
                }
            }

            _context.Entry(periodoInscripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeriodoInscripcionExists(id))
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

        // POST: api/ApiPeriodosInscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PeriodoInscripcion>> PostPeriodoInscripcion(PeriodoInscripcion periodoInscripcion)
        {
            _context.Attach(periodoInscripcion.CicloLectivo);
            if (periodoInscripcion.InscripcionHabilitada)
            {
                var periodos = _context.periodosinscripciones.Where(x => x.InscripcionHabilitada && x.Id != periodoInscripcion.Id).ToList();
                foreach (var item in periodos)
                {
                    item.InscripcionHabilitada = false;
                    _context.periodosinscripciones.Update(item);
                }
            }
            _context.periodosinscripciones.Add(periodoInscripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPeriodoInscripcion", new { id = periodoInscripcion.Id }, periodoInscripcion);
        }

        // DELETE: api/ApiPeriodosInscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeriodoInscripcion(int id)
        {
            var periodoInscripcion = await _context.periodosinscripciones.FindAsync(id);
            if (periodoInscripcion == null)
            {
                return NotFound();
            }
            periodoInscripcion.Eliminado = true;
            _context.Entry(periodoInscripcion).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PeriodoInscripcionExists(int id)
        {
            return _context.periodosinscripciones.Any(e => e.Id == id);
        }
    }
}
