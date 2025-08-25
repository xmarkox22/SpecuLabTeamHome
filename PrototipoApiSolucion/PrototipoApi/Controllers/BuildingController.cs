using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrototipoApi.Models;
using PrototipoApi.Application.Building.Queries.GetAllBuildings;
using PrototipoApi.Application.Building.Queries.GetBuildingById;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrototipoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BuildingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<BuildingDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] int floorCount = 0)
        {
            var result = await _mediator.Send(new GetAllBuildingsQuery(page, size, floorCount));
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BuildingDto>> GetById(int id)
        {
            var result = await _mediator.Send(new GetBuildingByIdQuery(id));
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BuildingDto>> Create([FromBody] BuildingDto dto)
        {
            var result = await _mediator.Send(new CreateBuildingCommand(dto));
            return CreatedAtAction(nameof(GetAll), new { id = result.BuildingId }, result);
        }
    }
}
