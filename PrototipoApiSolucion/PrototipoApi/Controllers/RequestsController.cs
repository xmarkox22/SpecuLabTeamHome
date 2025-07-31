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
    public async Task<ActionResult<IEnumerable<Request>>> GetRequests()
    {
        return await _context.Requests
            .ToListAsync();
    }

    // POST: api/requests = Crear una nueva solicitud
    [HttpPost]
    public async Task<ActionResult<Request>> CreateRequest(CreateRequestDto dto)
    {
        var request = new Request
        {
            RequestType = dto.RequestType ,
            Description = dto.Description,
            RequestDate = DateTime.UtcNow,
            RequestAmount = dto.RequestAmount, // Puedes ajustarlo desde el dto si es necesario
            Status = "Received" // Asignar un estado por defecto, puedes cambiarlo según tu lógica
        };

        _context.Requests.Add(request);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetRequests), new { id = request.RequestId }, request);
    }
}
