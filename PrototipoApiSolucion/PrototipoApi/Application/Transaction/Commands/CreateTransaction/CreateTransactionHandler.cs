using MediatR;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using System.Threading;
using System.Threading.Tasks;

public class CreateTransactionHandler : IRequestHandler<CreateTransactionCommand, TransactionDto>
{
    private readonly ContextoBaseDatos _context;

    public CreateTransactionHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<TransactionDto> Handle(CreateTransactionCommand request, CancellationToken cancellationToken)
    {
        var transaction = new Transaction
        {
            TransactionDate = request.TransactionDate,
            TransactionTypeId = request.TransactionTypeId,
            RequestId = request.RequestId
            // ManagementBudgetId = request.ManagementBudgetId
        };

        _context.Transactions.Add(transaction);
        await _context.SaveChangesAsync(cancellationToken);

        return new TransactionDto
        {
            TransactionId = transaction.TransactionId,
            TransactionDate = transaction.TransactionDate,
            TransactionTypeId = transaction.TransactionTypeId,
            RequestId = transaction.RequestId
            // ManagementBudgetId = transaction.ManagementBudgetId
        };
    }
}

