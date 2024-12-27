﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoServices.Models;
using InstitutoBack.DataContext;
using InstitutoServices.Models.Commons;
using InstitutoServices.Util;
using InstitutoServices.Class;

namespace InstitutoBack.Controllers.Commons
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiAnioCarrerasController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiAnioCarrerasController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiAnioCarreras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnioCarrera>>> Getanioscarreras([FromQuery] int? idCarrera)
        {
            if (idCarrera != null)
            {
                return await _context.anioscarreras.Include(a => a.Carrera).Where(a => a.CarreraId.Equals(idCarrera)).AsNoTracking().ToListAsync();
            }
            return await _context.anioscarreras.Include(a => a.Carrera).AsNoTracking().ToListAsync();
        }

        [HttpPost("filter")]
        public async Task<ActionResult<IEnumerable<AnioCarrera>>> Getanioscarreras([FromBody] List<FilterDTO> filters)
        {
            var filterExpression = BuilderPredicate.GetExpression<AnioCarrera>(filters);

            if (filterExpression == null)
            {
                return BadRequest("Invalid filter expression.");
            }
            return await _context.anioscarreras.Include(a => a.Carrera).Where(filterExpression).AsNoTracking().ToListAsync();
        }
        // GET: api/ApiAnioCarreras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnioCarrera>> GetAnioCarrera(int id)
        {
            var anioCarrera = await _context.anioscarreras.FindAsync(id);

            if (anioCarrera == null)
            {
                return NotFound();
            }

            return anioCarrera;
        }

        // PUT: api/ApiAnioCarreras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnioCarrera(int id, AnioCarrera anioCarrera)
        {
            if (id != anioCarrera.Id)
            {
                return BadRequest();
            }

            _context.Entry(anioCarrera).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AnioCarreraExists(id))
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

        // POST: api/ApiAnioCarreras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AnioCarrera>> PostAnioCarrera(AnioCarrera anioCarrera)
        {
            //attaching the carrera to avoid creating a new one
            //_context.Attach(anioCarrera?.Carrera);

            _context.anioscarreras.Add(anioCarrera);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAnioCarrera", new { id = anioCarrera.Id }, anioCarrera);
        }

        // DELETE: api/ApiAnioCarreras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnioCarrera(int id)
        {
            var anioCarrera = await _context.anioscarreras.FindAsync(id);
            if (anioCarrera == null)
            {
                return NotFound();
            }
            anioCarrera.Eliminado=true;
            _context.anioscarreras.Update(anioCarrera);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AnioCarreraExists(int id)
        {
            return _context.anioscarreras.Any(e => e.Id == id);
        }
    }
}
