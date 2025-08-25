using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrototipoApi.Application.ManagementBudget.Queries;
using PrototipoApi.Models;
using PrototipoApi.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrototipoApi.Controllers
{
    [Route("api/managementbudgets")]
    [ApiController]
    public class ManagementBudgetsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILoguer _loguer;

        public ManagementBudgetsController(IMediator mediator, ILoguer loguer)
        {
            _mediator = mediator;
            _loguer = loguer;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagementBudgetDto>>> GetManagementBudgets()
        {
            _loguer.LogInfo("Obteniendo todos los management budgets");
            var result = await _mediator.Send(new GetAllManagementBudgetsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            _loguer.LogInfo($"Obteniendo management budget con id {id}");
            var result = await _mediator.Send(new GetManagementBudgetByIdQuery(id));

            if (result == null)
            {
                _loguer.LogWarning($"Management budget con id {id} no encontrado");
                return NotFound();
            }

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateManagementBudgetDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            _loguer.LogInfo($"Actualizando management budget con id {id}");
            var result = await _mediator.Send(new UpdateManagementBudgetCommand(
                id,
                dto.CurrentAmount,
                dto.LastUpdatedDate
            ));

            if (result == null)
            {
                _loguer.LogWarning($"Management budget con id {id} no encontrado para actualizar");
                return NotFound();
            }

            _loguer.LogInfo($"Management budget actualizado con id {id}");
            return Ok(result);
        }
    }
}
