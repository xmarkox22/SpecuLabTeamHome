using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.Application.Common;
using PrototipoApi.Application.Requests.Commands.CreateRequest;
using PrototipoApi.Application.Requests.Commands.UpdateRequest;
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
    public async Task<ActionResult<PageResult<RequestDto>>> Get([FromQuery] GetAllRequestsQuery query)
    {
        var result = await _mediator.Send(query);
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
