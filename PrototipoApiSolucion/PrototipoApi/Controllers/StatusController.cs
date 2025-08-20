using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using System.Collections.Generic;
using System.Linq;
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
    }
}
