using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>
{
    private readonly ContextoBaseDatos _context;

    public GetAllTransactionsHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<List<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _context.Transactions
            .Include(t => t.Request)
            .Include(t => t.TransactionsType)
            .ToListAsync(cancellationToken);

        return transactions.Select(t => new TransactionDto
        {
            TransactionId = t.TransactionId,
            TransactionDate = t.TransactionDate,
            TransactionType = t.TransactionsType.TransactionName,
            TransactionTypeId = t.TransactionTypeId,
            RequestId = t.RequestId
            // ManagementBudgetId = t.ManagementBudgetId, // si se activa en el DTO
        }).ToList();
    }
}

