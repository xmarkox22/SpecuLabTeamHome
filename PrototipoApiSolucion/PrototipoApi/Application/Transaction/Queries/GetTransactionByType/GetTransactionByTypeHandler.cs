using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;

public class GetTransactionByTypeHandler : IRequestHandler<GetTransactionByTypeQuery, List<TransactionDto>>
{
    private readonly IRepository<Transaction> _repository;

    public GetTransactionByTypeHandler(IRepository<Transaction> repository)
    {
        _repository = repository;
    }

    public async Task<List<TransactionDto>> Handle(GetTransactionByTypeQuery request, CancellationToken cancellationToken)
    {
        var transactions = await _repository.GetAllAsync(null, t => t.Request, t => t.TransactionsType);
        var filtered = transactions.Where(t => t.TransactionsType.TransactionName == request.Type);

        return filtered.Select(t => new TransactionDto
        {
            TransactionId = t.TransactionId,
            TransactionDate = t.TransactionDate,
            TransactionType = t.TransactionsType.TransactionName,
            TransactionTypeId = t.TransactionTypeId,
            RequestId = t.RequestId,
            Description = t.Description
            // ManagementBudgetId = t.ManagementBudgetId
        }).ToList();
    }
}


