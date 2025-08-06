using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrototipoApi.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly ContextoBaseDatos _context;

        public StatusController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: api/status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetStatuses()
        {
            // Cargamos la lista de estados y proyectamos a DTO
            var statuses = await _context.Statuses.ToListAsync();

            var dtos = statuses.Select(s => new StatusDto
            {
                StatusId = s.StatusId,
                StatusType = s.StatusType,
                Description = s.Description
            }).ToList();

            return Ok(dtos);
        }

        // GET: api/status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDto>> GetStatus(int id)
        {
            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
                return NotFound();

            var dto = new StatusDto
            {
                StatusId = status.StatusId,
                StatusType = status.StatusType,
                Description = status.Description
            };

            return Ok(dto);
        }

        //// POST: api/status
        //[HttpPost]
        //public async Task<ActionResult<StatusDto>> PostStatus(StatusDto dto)
        //{
        //    // Validación (por si quieres agregarla, aunque no tengas relaciones)
        //    if (string.IsNullOrWhiteSpace(dto.StatusType))
        //        return BadRequest("StatusType no puede estar vacío.");

        //    var entity = new Status
        //    {
        //        StatusType = dto.StatusType,
        //        Description = dto.Description
        //    };

        //    _context.Statuses.Add(entity);
        //    await _context.SaveChangesAsync();

        //    dto.StatusId = entity.StatusId;

        //    return CreatedAtAction(nameof(GetStatus), new { id = dto.StatusId }, dto);
        //}

        //// PUT: api/status/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutStatus(int id, StatusDto dto)
        //{
        //    if (id != dto.StatusId)
        //        return BadRequest("El ID de la ruta y el del cuerpo no coinciden.");

        //    var entity = await _context.Statuses.FindAsync(id);
        //    if (entity == null)
        //        return NotFound();

        //    entity.StatusType = dto.StatusType;
        //    entity.Description = dto.Description;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!StatusExists(id))
        //            return NotFound();
        //        else
        //            throw;
        //    }

        //    return NoContent();
        //}

        //// DELETE: api/status/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteStatus(int id)
        //{
        //    var entity = await _context.Statuses.FindAsync(id);
        //    if (entity == null)
        //        return NotFound();

        //    _context.Statuses.Remove(entity);
        //    await _context.SaveChangesAsync();

        //    return NoContent();
        //}

        private bool StatusExists(int id)
        {
            return _context.Statuses.Any(e => e.StatusId == id);
        }
    }
}
