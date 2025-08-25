using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrototipoApi.Models;
using PrototipoApi.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrototipoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoguer _loguer;

        public BuildingController(IMediator mediator, ILoguer loguer)
        {
            _mediator = mediator;
            _loguer = loguer;
        }

        [HttpGet]
        public async Task<ActionResult<List<BuildingDto>>> GetAll([FromQuery] int page = 1, [FromQuery] int size = 10, [FromQuery] int floorCount = 0)
        {
            _loguer.LogInfo($"Obteniendo edificios. Página: {page}, Tamaño: {size}, FloorCount: {floorCount}");
            var result = await _mediator.Send(new GetAllBuildingsQuery(page, size, floorCount));
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<BuildingDto>> Create([FromBody] BuildingDto dto)
        {
            _loguer.LogInfo("Creando nuevo edificio");
            var result = await _mediator.Send(new CreateBuildingCommand(dto));
            _loguer.LogInfo($"Edificio creado con id {result.BuildingId}");
            return CreatedAtAction(nameof(GetAll), new { id = result.BuildingId }, result);
        }
    }
}
