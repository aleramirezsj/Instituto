﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using InstitutoServices.Models;
using InstitutoBack.DataContext;
using InstitutoServices.Models.Horarios;

namespace InstitutoBack.Controllers.Horarios
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiDetallesHorariosController : ControllerBase
    {
        private readonly InstitutoContext _context;

        public ApiDetallesHorariosController(InstitutoContext context)
        {
            _context = context;
        }

        // GET: api/ApiDetallesHorarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DetalleHorario>>> Getdetalleshorarios([FromQuery] int? idCicloLectivo, int? idCarrera, int? idAnioCarrera)
        {
            if (idAnioCarrera != null && idCicloLectivo != null)
            {
                return await _context.detalleshorarios
                    .Include(d => d.Aula)
                    .Include(d => d.Hora)
                    .Include(d => d.Horario)
                        .ThenInclude(h => h.Materia)
                            .ThenInclude(m => m.AnioCarrera)
                                .ThenInclude(a => a.Carrera)
                    .Include(d => d.Horario)
                        .ThenInclude(h => h.IntegrantesHorario)
                            .ThenInclude(i => i.Docente)
                    .Where(d => d.Horario.Materia.AnioCarreraId.Equals(idAnioCarrera) 
                        && d.Horario.CicloLectivoId.Equals(idCicloLectivo)).ToListAsync();
            }
            else
            {
                if (idCarrera != null && idCicloLectivo != null)
                {
                    return await _context.detalleshorarios
                        .Include(d => d.Aula)
                        .Include(d => d.Hora)
                        .Include(d => d.Horario)
                            .ThenInclude(h => h.Materia)
                                .ThenInclude(m => m.AnioCarrera)
                                    .ThenInclude(a => a.Carrera)
                        .Include(d => d.Horario)
                            .ThenInclude(h => h.IntegrantesHorario)
                                .ThenInclude(i => i.Docente)
                        .Where(d => d.Horario.Materia.AnioCarrera.CarreraId.Equals(idCarrera) 
                            && d.Horario.CicloLectivoId.Equals(idCicloLectivo)).ToListAsync();
                }
                else
                {
                    if (idCicloLectivo != null)
                    {
                        return await _context.detalleshorarios
                            .Include(d => d.Aula)
                            .Include(d => d.Hora)
                            .Include(d => d.Horario)
                                .ThenInclude(h => h.Materia)
                                    .ThenInclude(m => m.AnioCarrera)
                                        .ThenInclude(a => a.Carrera)
                            .Include(d => d.Horario)
                                .ThenInclude(h => h.IntegrantesHorario)
                                    .ThenInclude(i => i.Docente)
                            .Where(d =>d.Horario.CicloLectivoId.Equals(idCicloLectivo)).ToListAsync();
                    }
                }
            }
            return await _context.detalleshorarios
                .Include(d => d.Aula)
                .Include(d => d.Hora)
                .Include(d => d.Horario)
                        .ThenInclude(h => h.Materia)
                            .ThenInclude(m => m.AnioCarrera)
                                  .ThenInclude(a => a.Carrera)
                .Include(d => d.Horario)
                        .ThenInclude(h => h.IntegrantesHorario)
                                    .ThenInclude(i => i.Docente)
                .ToListAsync();
        }

        // GET: api/ApiDetallesHorarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DetalleHorario>> GetDetalleHorario(int id)
        {
            var detalleHorario = await _context.detalleshorarios.FindAsync(id);

            if (detalleHorario == null)
            {
                return NotFound();
            }

            return detalleHorario;
        }

        // PUT: api/ApiDetallesHorarios/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDetalleHorario(int id, DetalleHorario detalleHorario)
        {
            if (id != detalleHorario.Id)
            {
                return BadRequest();
            }

            _context.Entry(detalleHorario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleHorarioExists(id))
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

        // POST: api/ApiDetallesHorarios
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DetalleHorario>> PostDetalleHorario(DetalleHorario detalleHorario)
        {
            _context.detalleshorarios.Add(detalleHorario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleHorario", new { id = detalleHorario.Id }, detalleHorario);
        }

        // DELETE: api/ApiDetallesHorarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDetalleHorario(int id)
        {
            var detalleHorario = await _context.detalleshorarios.FindAsync(id);
            if (detalleHorario == null)
            {
                return NotFound();
            }

            detalleHorario.Eliminado=true;
            _context.detalleshorarios.Update(detalleHorario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DetalleHorarioExists(int id)
        {
            return _context.detalleshorarios.Any(e => e.Id == id);
        }
    }
}
