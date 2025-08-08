using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;
using System.Threading;
using System.Threading.Tasks;

public class GetTransactionByIdHandler : IRequestHandler<GetTransactionByIdQuery, TransactionDto?>
{
    private readonly ContextoBaseDatos _context;

    public GetTransactionByIdHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<TransactionDto?> Handle(GetTransactionByIdQuery request, CancellationToken cancellationToken)
    {
        var transaction = await _context.Transactions
            .Include(t => t.Request)
            .Include(t => t.TransactionsType)
            .FirstOrDefaultAsync(t => t.TransactionId == request.Id, cancellationToken);

        if (transaction == null) return null;

        return new TransactionDto
        {
            TransactionId = transaction.TransactionId,
            TransactionDate = transaction.TransactionDate,
            TransactionType = transaction.TransactionsType.TransactionName,
            TransactionTypeId = transaction.TransactionTypeId,
            RequestId = transaction.RequestId,
            // ManagementBudgetId = transaction.ManagementBudgetId // si lo usas
        };
    }
}

