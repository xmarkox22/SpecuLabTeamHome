using MediatR;
using Microsoft.AspNetCore.Mvc;
using PrototipoApi.Models;
using PrototipoApi.Application.Status.Commands.UpdateStatus;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrototipoApi.Controllers
{
    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/status
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDto>>> GetStatuses()
        {
            var statuses = await _mediator.Send(new GetAllStatusQuery());
            return Ok(statuses);
        }

        // GET: api/status/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StatusDto>> GetStatus(int id)
        {
            var status = await _mediator.Send(new GetStatusByIdQuery(id));
            if (status == null)
                return NotFound();

            return Ok(status);
        }

        // POST: api/status
        [HttpPost]
        public async Task<ActionResult<StatusDto>> PostStatus(CreateStatusDto dto)
        {
            var createdStatus = await _mediator.Send(new CreateStatusCommand(dto.StatusType, dto.Description));
            return CreatedAtAction(nameof(GetStatus), new { id = createdStatus.StatusId }, createdStatus);
        }

        // PUT: api/status/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStatus(int id, [FromBody] StatusDto dto)
        {
            var success = await _mediator.Send(new UpdateStatusCommand(id, dto.StatusType, dto.Description));
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
