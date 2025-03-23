using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoServices.Models;
using InstitutoBack.DataContext;
using InstitutoServices.Models.Commons;
using System.Linq.Expressions;
using System.Text.Json;
using Newtonsoft.Json;
using InstitutoServices.Class;
using InstitutoServices.Util;

namespace InstitutoBack.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAlumnosController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiAlumnosController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiAlumnos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alumno>>> Getalumnos()
        {
            return await _context.alumnos
                .Include(alumno=>alumno.InscripcionesACarreras)
                .ThenInclude(inscripcion => inscripcion.Carrera)
                .AsNoTracking().ToListAsync();
        }
        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<Alumno>>> Getalumnos([FromBody] List<FilterDTO> filters)
        {
            var filterExpression = BuilderPredicate.GetExpression<Alumno>(filters);

            if (filterExpression == null)
            {
                return BadRequest("Invalid filter expression.");
            }
            return await _context.alumnos.Include(alumno => alumno.InscripcionesACarreras).Where(filterExpression).AsNoTracking().ToListAsync();
        }

        // GET: api/ApiAlumnos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Alumno>> GetAlumno(int id)
        {
            var alumno = await _context.alumnos.Include(alumno => alumno.InscripcionesACarreras).FirstOrDefaultAsync(alumno=>alumno.Id==id);

            if (alumno == null)
            {
                return NotFound();
            }

            return alumno;
        }

        // PUT: api/ApiAlumnos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumno(int id, Alumno alumno)
        {
            if (id != alumno.Id)
            {
                return BadRequest();
            }

            _context.Entry(alumno).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlumnoExists(id))
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

        // POST: api/ApiAlumnos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Alumno>> PostAlumno(Alumno alumno)
        {
            _context.alumnos.Add(alumno);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlumno", new { id = alumno.Id }, alumno);
        }

        // DELETE: api/ApiAlumnos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumno(int id)
        {
            var alumno = await _context.alumnos.FindAsync(id);
            if (alumno == null)
            {
                return NotFound();
            }
            alumno.Eliminado=true;
            _context.alumnos.Update(alumno);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AlumnoExists(int id)
        {
            return _context.alumnos.Any(e => e.Id == id);
        }
    }
}
