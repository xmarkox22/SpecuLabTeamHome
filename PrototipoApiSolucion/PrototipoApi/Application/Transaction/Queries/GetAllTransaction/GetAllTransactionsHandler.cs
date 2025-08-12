using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;
using PrototipoApi.Entities;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, List<TransactionDto>>
{
    private readonly IRepository<Transaction> _repository;

    public GetAllTransactionsHandler(IRepository<Transaction> repository)
    {
        _repository = repository;
    }

    public async Task<List<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _repository.GetAllAsync(null, t => t.Request, t => t.TransactionsType);

        return transactions.Select(t => new TransactionDto
        {
            TransactionId = t.TransactionId,
            TransactionDate = t.TransactionDate,
            TransactionType = t.TransactionsType.TransactionName,
            TransactionTypeId = t.TransactionTypeId,
            RequestId = t.RequestId,
            Description = t.Description
            // ManagementBudgetId = t.ManagementBudgetId, // si se activa en el DTO
        }).ToList();
    }
}

