﻿using System;
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
    public class ApiInscripcionesController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiInscripcionesController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiInscripciones
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inscripcion>>> Getinscripciones()
        {
            return await _context.inscripciones.Include(i => i.Carrera).Include(i => i.Alumno).ToListAsync();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<Inscripcion>>> Getinscripciones([FromBody] List<FilterDTO> filters)
        {
            var filterExpression = BuilderPredicate.GetExpression<Inscripcion>(filters);

            if (filterExpression == null)
            {
                return BadRequest("Invalid filter expression.");
            }
            return await _context.inscripciones.Include(i => i.Carrera).Include(i => i.Alumno).Where(filterExpression).ToListAsync();
        }


        // GET: api/ApiInscripciones/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inscripcion>> GetInscripcion(int id)
        {
            var inscripcion = await _context.inscripciones.FindAsync(id);

            if (inscripcion == null)
            {
                return NotFound();
            }

            return inscripcion;
        }

        // PUT: api/ApiInscripciones/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInscripcion(int id, Inscripcion inscripcion)
        {
            if (id != inscripcion.Id)
            {
                return BadRequest();
            }

            _context.Entry(inscripcion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InscripcionExists(id))
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

        // POST: api/ApiInscripciones
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Inscripcion>> PostInscripcion(Inscripcion inscripcion)
        {
            _context.inscripciones.Add(inscripcion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInscripcion", new { id = inscripcion.Id }, inscripcion);
        }

        // DELETE: api/ApiInscripciones/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInscripcion(int id)
        {
            var inscripcion = await _context.inscripciones.FindAsync(id);
            if (inscripcion == null)
            {
                return NotFound();
            }

            inscripcion.Eliminado = true;
            _context.inscripciones.Update(inscripcion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InscripcionExists(int id)
        {
            return _context.inscripciones.Any(e => e.Id == id);
        }
    }
}
