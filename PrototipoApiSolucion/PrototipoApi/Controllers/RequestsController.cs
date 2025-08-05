using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using System;

[Route("api/requests")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly ContextoBaseDatos _context;

    public RequestsController(ContextoBaseDatos context)
    {
        _context = context;
    }

    // GET: api/requests
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RequestDto>>> GetRequests()
    {
        var requests = await _context.Requests
            .Include(r => r.Status)
            .Include(r => r.Building)
            .ToListAsync();

        var requestDtos = requests.Select(r => new RequestDto
        {
            RequestId = r.RequestId,
            BuildingAmount = r.BuildingAmount,
            MaintenanceAmount = r.MaintenanceAmount,
            Description = r.Description,
            StatusType = r.Status.StatusType,
            BuildingStreet = r.Building.Street
        }).ToList();

        return Ok(requestDtos);
    }

    // GET: api/requests/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<RequestDto>> GetRequest(int id)
    {
        var requestDto = await _context.Requests
            .Include(r => r.Status)
            .Include(r => r.Building)
            .Where(r => r.RequestId == id)
            .Select(r => new RequestDto
            {
                RequestId = r.RequestId,
                BuildingAmount = r.BuildingAmount,
                MaintenanceAmount = r.MaintenanceAmount,
                Description = r.Description,
                StatusType = r.Status.StatusType,
                BuildingStreet = r.Building.Street
            })
            .FirstOrDefaultAsync();

        if (requestDto == null)
        {
            return NotFound();
        }

        return Ok(requestDto);
    }

    // POST: api/requests
    [HttpPost]
    public async Task<ActionResult<RequestDto>> CreateRequest(CreateRequestDto dto)
    {
        var request = new Request
        {
            Description = dto.Description,
            RequestDate = DateTime.UtcNow,
            BuildingAmount = dto.BuildingAmount,
            MaintenanceAmount = dto.MaintenanceAmount,
            StatusId = dto.StatusId,
            BuildingId = dto.BuildingId
        };

        _context.Requests.Add(request);
        await _context.SaveChangesAsync();

        // Mapear a DTO de salida
        var resultDto = new RequestDto
        {
            RequestId = request.RequestId,
            BuildingAmount = request.BuildingAmount,
            MaintenanceAmount = request.MaintenanceAmount,
            Description = request.Description,
            StatusType = (await _context.Statuses.FindAsync(request.StatusId))?.StatusType ?? "Desconocido",
            BuildingStreet = (await _context.Buildings.FindAsync(request.BuildingId))?.Street ?? "Desconocido"
        };

        return CreatedAtAction(nameof(GetRequest), new { id = request.RequestId }, resultDto);
    }
}
