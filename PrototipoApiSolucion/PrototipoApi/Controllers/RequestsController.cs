using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.Application.Requests.Queries.GetRequestById;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using System;

[Route("api/requests")]
[ApiController]
public class RequestsController : ControllerBase
{
    private readonly IMediator _mediator;

    public RequestsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<List<RequestDto>>> Get()
    {
        var result = await _mediator.Send(new GetAllRequestsQuery());
        return Ok(result);
    }

   [HttpGet("{id}")]
    public async Task<ActionResult<RequestDto>> GetById(int id)
    {
        var result = await _mediator.Send(new GetRequestByIdQuery(id));
        if (result == null)
            return NotFound();
        return Ok(result);
    }

    // Get by status 
    [HttpGet("status/{status}")]
    public async Task<ActionResult<IEnumerable<RequestDto>>> GetRequestsByStatus(string status)
    {
        var result = await _mediator.Send(new GetRequestByStatusQuery(status));
        return Ok(result);
    }


    [HttpPost]
    public async Task<ActionResult<RequestDto>> CreateRequest([FromBody] CreateRequestDto dto)
    {
        var result = await _mediator.Send(new CreateRequestCommand(dto));
        // Devuelve 201 Created (puedes ajustar la URL según tu método GET)
        return CreatedAtAction(nameof(GetById), new { id = result.RequestId }, result);
    }

    //private readonly ContextoBaseDatos _context;

    //public RequestsController(ContextoBaseDatos context)
    //{
    //    _context = context;
    //}

    //// GET: api/requests
    //[HttpGet]
    //public async Task<ActionResult<IEnumerable<RequestDto>>> GetRequests()
    //{
    //    var requests = await _context.Requests
    //        .Include(r => r.Status)
    //        .Include(r => r.Building)
    //        .ToListAsync();

    //    var requestDtos = requests.Select(r => new RequestDto
    //    {
    //        RequestId = r.RequestId,
    //        BuildingAmount = r.BuildingAmount,
    //        MaintenanceAmount = r.MaintenanceAmount,
    //        Description = r.Description,
    //        StatusId = r.StatusId,
    //        StatusType = r.Status.StatusType,
    //        BuildingId = r.BuildingId,
    //        BuildingStreet = r.Building.Street
    //    }).ToList();

    //    return Ok(requestDtos);
    //}

    //// GET: api/requests/{id}
    //[HttpGet("{id}")]
    //public async Task<ActionResult<RequestDto>> GetRequest(int id)
    //{
    //    var requestDto = await _context.Requests
    //        .Include(r => r.Status)
    //        .Include(r => r.Building)
    //        .Where(r => r.RequestId == id)
    //        .Select(r => new RequestDto
    //        {
    //            RequestId = r.RequestId,
    //            BuildingAmount = r.BuildingAmount,
    //            MaintenanceAmount = r.MaintenanceAmount,
    //            Description = r.Description,
    //            StatusId = r.StatusId,
    //            StatusType = r.Status.StatusType,
    //            BuildingId = r.BuildingId,
    //            BuildingStreet = r.Building.Street
    //        })
    //        .FirstOrDefaultAsync();

    //    if (requestDto == null)
    //        return NotFound();

    //    return Ok(requestDto);
    //}

    //// POST: api/requests
    //[HttpPost]
    //public async Task<ActionResult<RequestDto>> CreateRequest(CreateRequestDto dto)
    //{
    //    // Validación opcional para asegurar que los IDs existen
    //    var buildingExists = await _context.Buildings.AnyAsync(b => b.BuildingId == dto.BuildingId);
    //    if (!buildingExists)
    //        return BadRequest("El edificio especificado no existe.");

    //    var statusExists = await _context.Statuses.AnyAsync(s => s.StatusId == dto.StatusId);
    //    if (!statusExists)
    //        return BadRequest("El estado especificado no existe.");

    //    // Crear la request relacionando los IDs
    //    var r = new Request
    //    {
    //        Description = dto.Description,
    //        RequestDate = DateTime.UtcNow,
    //        BuildingAmount = dto.BuildingAmount,
    //        MaintenanceAmount = dto.MaintenanceAmount,
    //        StatusId = dto.StatusId,
    //        BuildingId = dto.BuildingId
    //    };

    //    _context.Requests.Add(r);
    //    await _context.SaveChangesAsync();

    //    // Obtener los datos relacionados (para el DTO de salida)
    //    var status = await _context.Statuses.FindAsync(r.StatusId);
    //    var building = await _context.Buildings.FindAsync(r.BuildingId);

    //    var createdDto = new RequestDto
    //    {
    //        RequestId = r.RequestId,
    //        BuildingAmount = r.BuildingAmount,
    //        MaintenanceAmount = r.MaintenanceAmount,
    //        Description = r.Description,
    //        StatusId = r.StatusId,
    //        StatusType = status?.StatusType ?? "",
    //        BuildingId = r.BuildingId,
    //        BuildingStreet = building?.Street ?? ""
    //    };

    //    return CreatedAtAction(nameof(GetRequest), new { id = r.RequestId }, createdDto);
    //}

    //// Get by status 
    //[HttpGet("status/{status}")]
    //public async Task<ActionResult<IEnumerable<RequestDto>>> GetRequestsByStatus(string status)
    //{
    //    var requests = await _context.Requests
    //        .Include(r => r.Status)
    //        .Include(r => r.Building)
    //        .Where(r => r.Status.StatusType == status)
    //        .ToListAsync();
    //    if (!requests.Any())
    //        return NotFound();
    //    var requestDtos = requests.Select(r => new RequestDto
    //    {
    //        RequestId = r.RequestId,
    //        BuildingAmount = r.BuildingAmount,
    //        MaintenanceAmount = r.MaintenanceAmount,
    //        Description = r.Description,
    //        StatusId = r.StatusId,
    //        StatusType = r.Status.StatusType,
    //        BuildingId = r.BuildingId,
    //        BuildingStreet = r.Building.Street
    //    }).ToList();
    //    return Ok(requestDtos);
    //}

    //// PUT: api/requests/{id}
    //[HttpPut("{id}/amounts")]
    //public async Task<IActionResult> UpdateRequestAmounts(int id, [FromBody] UpdateRequestDto dto)
    //{
    //    var request = await _context.Requests.FindAsync(id);

    //    if (request == null)
    //        return NotFound($"No se encontró la solicitud con ID {id}");

    //    request.BuildingAmount = dto.BuildingAmount;
    //    request.MaintenanceAmount = dto.MaintenanceAmount;

    //    await _context.SaveChangesAsync();

    //    return NoContent(); // o return Ok(request); si quieres devolver la solicitud actualizada
    //}
}
