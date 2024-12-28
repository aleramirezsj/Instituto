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
using InstitutoServices.Models.Horarios;

namespace InstitutoBack.Controllers.MesasExamenes
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiMesasExamenesController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiMesasExamenesController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiMesasExamenes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MesaExamen>>> Getmesasexamenes([FromQuery] int? idCarrera, int? idTurno)
        {
            if (idCarrera != null && idTurno != null)
            {
                return await _context.mesasexamenes
                    .Include(m => m.TurnoExamen)
                    .Include(m => m.DetallesMesaExamen)
                            .ThenInclude(d => d.Docente)
                    .Include(m => m.Materia)
                            .ThenInclude(m => m.AnioCarrera)
                            .ThenInclude(a => a.Carrera)
                    .Where(m => m.Materia.AnioCarrera.CarreraId == idCarrera && m.TurnoExamenId == idTurno).AsNoTracking().ToListAsync();
            }
            return await _context.mesasexamenes
                .Include(m=>m.TurnoExamen)
                .Include(m => m.DetallesMesaExamen)
                            .ThenInclude(d => d.Docente)
                    .Include(m => m.Materia)
                            .ThenInclude(m => m.AnioCarrera)
                            .ThenInclude(a => a.Carrera)
                            .AsNoTracking()
                .ToListAsync();
        }

        // GET: api/ApiMesasExamenes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MesaExamen>> GetMesaExamen(int id)
        {
            var mesaExamen = await _context.mesasexamenes
                .Include(m => m.DetallesMesaExamen)
                            .ThenInclude(d => d.Docente)
                    .Include(m => m.Materia)
                            .ThenInclude(m => m.AnioCarrera)
                            .ThenInclude(a => a.Carrera)
                .Where(m=>m.Id.Equals(id)).FirstOrDefaultAsync();

            if (mesaExamen == null)
            {
                return NotFound();
            }

            return mesaExamen;
        }

        // PUT: api/ApiMesasExamenes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMesaExamen(int id, MesaExamen mesaExamen)
        {
            if (id != mesaExamen.Id)
            {
                return BadRequest();
            }
            #region attach materia turno y detalles
            _context.Attach(mesaExamen.Materia);
            //attach turno
            _context.Attach(mesaExamen.TurnoExamen);
            //attach detalles
            foreach (var detalle in mesaExamen.DetallesMesaExamen)
            {
                _context.Attach(detalle.Docente);
            }
            #endregion

            //busco los detalles existentes
            var detallesExistentes = _context.detallesmesasexamenes.Where(d => d.MesaExamenId.Equals(mesaExamen.Id)).AsNoTracking().ToList();
            

            //busco los detalles que se eliminaron
            var detallesEliminados = detallesExistentes.Where(d => !mesaExamen.DetallesMesaExamen.Any(dm => dm.Id == d.Id)).ToList();


            foreach (var detalle in mesaExamen.DetallesMesaExamen)
            {
                if (detalle.Id == 0)
                {
                    _context.detallesmesasexamenes.Add(detalle);
                }
                else
                {
                    _context.Entry(detalle).State = EntityState.Modified;
                }
            }

            
            foreach (var detalle in detallesEliminados)
            {
                _context.detallesmesasexamenes.Remove(detalle);
            }

            _context.Entry(mesaExamen).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
           

            catch (DbUpdateConcurrencyException)
            {
                if (!MesaExamenExists(id))
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

        // POST: api/ApiMesasExamenes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MesaExamen>> PostMesaExamen(MesaExamen mesaExamen)
        {
            //attach materia
            _context.Attach(mesaExamen.Materia);
            //attach turno
            _context.Attach(mesaExamen.TurnoExamen);
            //attach detalles
            foreach (var detalle in mesaExamen.DetallesMesaExamen)
            {
                _context.Attach(detalle.Docente);
            }
            _context.mesasexamenes.Add(mesaExamen);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMesaExamen", new { id = mesaExamen.Id }, mesaExamen);
        }

        // DELETE: api/ApiMesasExamenes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMesaExamen(int id)
        {
            var mesaExamen = await _context.mesasexamenes.FindAsync(id);
            if (mesaExamen == null)
            {
                return NotFound();
            }

            mesaExamen.Eliminado = true;
            _context.mesasexamenes.Update(mesaExamen);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MesaExamenExists(int id)
        {
            return _context.mesasexamenes.Any(e => e.Id == id);
        }
    }
}
