using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using PrototipoApi.Application.Common;

namespace PrototipoApi.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TransactionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: api/transactions
        [HttpGet]
        public async Task<ActionResult<PageResult<TransactionDto>>> GetTransactions([FromQuery] string? transactionType, [FromQuery] int page = 0, [FromQuery] int size = 10)
        {
            var transactions = await _mediator.Send(new GetAllTransactionsQuery(transactionType, page, size));
            return Ok(transactions);
        }

        // GET: api/transactions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetTransaction(int id)
        {
            var transaction = await _mediator.Send(new GetTransactionByIdQuery(id));
            if (transaction == null)
                return NotFound();

            return Ok(transaction);
        }

       
        // PUT: api/transactions/{id}
        [HttpPut("{id}")]


        // POST: api/transactions
        [HttpPost]
        public async Task<ActionResult<TransactionDto>> CreateTransaction(TransactionDto dto)
        {
            var createdTransaction = await _mediator.Send(
                new CreateTransactionCommand(dto.TransactionDate, dto.TransactionTypeId, dto.RequestId)
            );

            return CreatedAtAction(nameof(GetTransaction), new { id = createdTransaction.TransactionId }, createdTransaction);
        }

    }

}
