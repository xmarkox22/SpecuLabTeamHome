using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;

namespace PrototipoApi.Controllers
{
    [Route("api/transactions")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ContextoBaseDatos _context;

        public TransactionsController(ContextoBaseDatos context)
        {
            _context = context;
        }

        // GET: api/transactions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactions()
        {
            var transactions = await _context.Transactions
                .Include(t => t.Request)
                .Include(t => t.TransactionsType)
                .ToListAsync();
            var transactionDtos = transactions.Select(t => new TransactionDto
            {
                TransactionId = t.TransactionId,
                TransactionDate = t.TransactionDate,
                TransactionType = t.TransactionsType.TransactionName,
                TransactionTypeId = t.TransactionTypeId,
                RequestId = t.RequestId,
                //ManagementBudgetId = t.ManagementBudgetId,
            }).ToList();
            return Ok(transactionDtos);
        }


        // GET: api/transactions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetTransaction(int id)
        {
            var transaction = await _context.Transactions
                .Include(t => t.Request)
                .Include(t => t.TransactionsType)
                .FirstOrDefaultAsync(t => t.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }
            var transactionDto = new TransactionDto
            {
                TransactionId = transaction.TransactionId,
                TransactionDate = transaction.TransactionDate,
                TransactionType = transaction.TransactionsType.TransactionName,
                RequestId = transaction.RequestId,
                //ManagementBudgetId = transaction.ManagementBudgetId
            };
            return Ok(transactionDto);
        }

        //GET by type: api/transactions/type/{type}
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactionsByType(string type)
        {
            var transactions = await _context.Transactions
                .Where(t => t.TransactionsType.TransactionName == type)
                .Include(t => t.Request)
                .ToListAsync();
            if (transactions.Count == 0)
            {
                return NotFound();
            }
            var transactionDtos = transactions.Select(t => new TransactionDto
            {
                TransactionId = t.TransactionId,
                TransactionDate = t.TransactionDate,
                TransactionType = t.TransactionsType.TransactionName,
                RequestId = t.RequestId,
                //ManagementBudgetId = t.ManagementBudgetId
            }).ToList();
            return Ok(transactionDtos);
        }

        // PUT: api/transactions/{id}
        [HttpPut("{id}")]


        // POST: api/transactions
        [HttpPost]
        public async Task<ActionResult<TransactionDto>> CreateTransaction(TransactionDto dto)
        {
            var t = new Transaction
            {
                TransactionDate = dto.TransactionDate,
                //TransactionType = transactionDto.TransactionType,
                TransactionTypeId = dto.TransactionTypeId,
                RequestId = dto.RequestId,
                AssociatedBudgetId = dto.AssociatedBudgetId
            };
            _context.Transactions.Add(t);
            await _context.SaveChangesAsync();
            dto.TransactionId = t.TransactionId;
            return CreatedAtAction(nameof(GetTransaction), new { id = t.TransactionId });

        }
    }

}
