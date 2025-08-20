using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrototipoApi.Application.ManagementBudget.Queries;
using PrototipoApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrototipoApi.Controllers
{
    [Route("api/managementbudgets")]
    [ApiController]
    public class ManagementBudgetsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManagementBudgetsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagementBudgetDto>>> GetManagementBudgets()
        {
            var result = await _mediator.Send(new GetAllManagementBudgetsQuery());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetManagementBudgetByIdQuery(id));

            if (result == null)
                return NotFound();

            return Ok(result);
        }


        // PUT: api/ManagementBudgets/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateManagementBudgetDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _mediator.Send(new UpdateManagementBudgetCommand(
                id,
                dto.CurrentAmount,
                dto.LastUpdatedDate
            ));

            if (result == null)
                return NotFound();

            return Ok(result);

        }
    }
}
