using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.Application.Requests.Commands.UpdateRequest.PrototipoApi.Application.Requests.Commands.UpdateRequest;
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

    [HttpPut("{id}/amounts")]
    public async Task<IActionResult> UpdateAmounts(int id, [FromBody] UpdateRequestDto dto)
    {
        var success = await _mediator.Send(new UpdateRequestCommand(id, dto));

        if (!success)
            return NotFound($"No se encontró la solicitud con ID {id}");

        return NoContent(); // o return Ok() si prefieres confirmar
    }


}
