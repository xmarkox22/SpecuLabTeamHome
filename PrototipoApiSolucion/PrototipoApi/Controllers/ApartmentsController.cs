using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrototipoApi.Models;
using PrototipoApi.Logging;
using PrototipoApi.Application.Apartments.Queries;
using PrototipoApi.Application.Apartments.Commands;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrototipoApi.Application.Apartments.Queries.GetAllApartments;
using PrototipoApi.Application.Apartments.Queries.GetApartmentById;
using PrototipoApi.Application.Apartments.Commands.CreateApartment;

namespace PrototipoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoguer _loguer;

        public ApartmentsController(IMediator mediator, ILoguer loguer)
        {
            _mediator = mediator;
            _loguer = loguer;
        }

        [HttpGet]
        public async Task<ActionResult<List<ApartmentDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] string? orderBy = "CreatedDate", [FromQuery] bool desc = true)
        {
            _loguer.LogInfo($"Obteniendo apartamentos. Página: {page}, Tamaño: {size}, Orden: {orderBy}, Desc: {desc}");
            var result = await _mediator.Send(new GetAllApartmentsQuery(page, size, orderBy, desc));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApartmentDto>> GetById(int id)
        {
            _loguer.LogInfo($"Obteniendo apartamento con id {id}");
            var result = await _mediator.Send(new GetApartmentByIdQuery(id));
            if (result == null)
            {
                _loguer.LogWarning($"Apartamento con id {id} no encontrado");
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<ApartmentDto>> Create([FromBody] ApartmentDto dto)
        {
            _loguer.LogInfo("Creando nuevo apartamento");
            var result = await _mediator.Send(new CreateApartmentCommand(dto));
            _loguer.LogInfo($"Apartamento creado con id {result.ApartmentId}");
            return CreatedAtAction(nameof(GetById), new { id = result.ApartmentId }, result);
        }
    }
}
