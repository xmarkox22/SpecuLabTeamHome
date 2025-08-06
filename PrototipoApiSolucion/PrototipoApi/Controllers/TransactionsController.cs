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
            var transactions = await _context.Transaction
                .Include(t => t.Request)
                .ToListAsync();
            var transactionDtos = transactions.Select(t => new TransactionDto
            {
                TransactionId = t.TransactionId,
                TransactionDate = t.TransactionDate,
                TransactionType = t.TransactionType,
                RequestId = t.RequestId,
                AssociatedBudgetId = t.AssociatedBudgetId.ToString()
            }).ToList();
            return Ok(transactionDtos);
        }


        // GET: api/transactions/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionDto>> GetTransaction(int id)
        {
            var transaction = await _context.Transaction
                .Include(t => t.Request)
                .FirstOrDefaultAsync(t => t.TransactionId == id);
            if (transaction == null)
            {
                return NotFound();
            }
            var transactionDto = new TransactionDto
            {
                TransactionId = transaction.TransactionId,
                TransactionDate = transaction.TransactionDate,
                TransactionType = transaction.TransactionType,
                RequestId = transaction.RequestId,
                AssociatedBudgetId = transaction.AssociatedBudgetId.ToString()
            };
            return Ok(transactionDto);
        }

        //GET by type: api/transactions/type/{type}
        [HttpGet("type/{type}")]
        public async Task<ActionResult<IEnumerable<TransactionDto>>> GetTransactionsByType(string type)
        {
            var transactions = await _context.Transaction
                .Where(t => t.TransactionType == type)
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
                TransactionType = t.TransactionType,
                RequestId = t.RequestId,
                AssociatedBudgetId = t.AssociatedBudgetId.ToString()
            }).ToList();
            return Ok(transactionDtos);
        }

        // POST: api/transactions
        [HttpPost]
        public async Task<ActionResult<TransactionDto>> CreateTransaction(TransactionDto transactionDto)
        {
            var transaction = new Transaction
            {
                TransactionDate = transactionDto.TransactionDate,
                TransactionType = transactionDto.TransactionType,
                RequestId = transactionDto.RequestId,
                AssociatedBudgetId = int.Parse(transactionDto.AssociatedBudgetId)
            };
            _context.Transaction.Add(transaction);
            await _context.SaveChangesAsync();
            transactionDto.TransactionId = transaction.TransactionId;
            return CreatedAtAction(nameof(GetTransaction), new { id = transaction.TransactionId });

        }
    }

}
