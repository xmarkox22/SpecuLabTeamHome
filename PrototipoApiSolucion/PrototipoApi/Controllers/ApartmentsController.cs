using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrototipoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

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
            var result = await _mediator.Send(new Application.Apartments.Queries.GetAllApartmentsQuery(page, size, orderBy, desc));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApartmentDto>> GetById(int id)
        {
            var result = await _mediator.Send(new Application.Apartments.Queries.GetApartmentByIdQuery(id));
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
            var result = await _mediator.Send(new Application.Apartments.Commands.CreateApartmentCommand(dto));
            return CreatedAtAction(nameof(GetById), new { id = result.ApartmentId }, result);
        }
    }
}
