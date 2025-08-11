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

            var result = await _mediator.Send(new UpdateManagementBudgetCommand(
                dto.CurrentAmount,
                dto.LastUpdatedDate
            ));

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        //// POST: api/ManagementBudgets
        //[HttpPost]
        //public async Task<ActionResult<ManagementBudgetDto>> PostManagementBudget(ManagementBudgetDto dto)
        //{
        //    var entity = new ManagementBudget
        //    {
        //        InitialAmount = dto.InitialAmount,
        //        CurrentAmount = dto.CurrentAmount,
        //        LastUpdatedDate = dto.LastUpdatedDate
        //    };
        //    _context.ManagementBudget.Add(entity);
        //    await _context.SaveChangesAsync();
        //    dto.ManagementBudgetId = entity.ManagementBudgetId;
        //    return CreatedAtAction(nameof(GetManagementBudget), new { id = entity.ManagementBudgetId }, dto);
        //}

        //// DELETE: api/ManagementBudgets/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteManagementBudget(int id)
        //{
        //    var entity = await _context.ManagementBudget.FindAsync(id);
        //    if (entity == null)
        //        return NotFound();
        //    _context.ManagementBudget.Remove(entity);
        //    await _context.SaveChangesAsync();
        //    return NoContent();
        //}

        //private bool ManagementBudgetExists(int id)
        //{
        //    return _context.ManagementBudgets.Any(e => e.ManagementBudgetId == id);
        //}
    }
}
