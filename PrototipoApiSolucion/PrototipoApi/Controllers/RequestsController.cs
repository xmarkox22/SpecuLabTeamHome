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


    // GET: api/requests = Listar todas las solicitudes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Request>>> GetRequests() // Devolver dtos y no entidades directamente
    {
        // Obtener con DTOs todas las requests

        var requests = await _context.Requests
            .Include(r => r.Status)
            .Include(r => r.Building)
            .ToListAsync();

        // Mapear las entidades a DTOs
        var requestDtos = requests.Select(r => new RequestDto
        {
            RequestDtoId = r.RequestId,
            BuilidingAmount = r.BuilidingAmount,
            MaintenanceAmount = r.MaintenanceAmount,
            Description = r.Description,
            Status = r.Status,
            Building = r.Building
        }).ToList();

        return requests;

    }

    // GET: api/requests/{id} = Obtener una solicitud por ID
    [HttpGet("{id}")]
    public async Task<ActionResult<Request>> GetRequest(int id)
    {
        var request = await _context.Requests.FindAsync(id);
        if (request == null)
        {
            return NotFound();
        }
        return request;
    }


    // POST: api/requests = Crear una nueva solicitud
    [HttpPost]
    public async Task<ActionResult<Request>> CreateRequest(RequestDto dto)
    {
        var request = new Request
        {
            Description = dto.Description,
            RequestDate = DateTime.UtcNow,
            BuilidingAmount = dto.BuilidingAmount,
            MaintenanceAmount = dto.MaintenanceAmount,
            Status = dto.Status,
            Building = dto.Building
        };

        _context.Requests.Add(request);
        await _context.SaveChangesAsync();

        return Created("", $"La solicitud de compra se ha creado correctamente con id {request.RequestId} Puede consultar su estado enviando una petición GET con ese ID");
    }
}
