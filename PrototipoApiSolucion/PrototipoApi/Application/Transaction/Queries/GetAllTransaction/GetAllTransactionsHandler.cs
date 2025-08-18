using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;
using PrototipoApi.Entities;
using PrototipoApi.Application.Common;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System.Linq.Expressions;

public class GetAllTransactionsHandler : IRequestHandler<GetAllTransactionsQuery, PageResult<TransactionDto>>
{
    private readonly IRepository<Transaction> _repository;

    public GetAllTransactionsHandler(IRepository<Transaction> repository)
    {
        _repository = repository;
    }

    public async Task<PageResult<TransactionDto>> Handle(GetAllTransactionsQuery request, CancellationToken cancellationToken)
    {
        Expression<Func<Transaction, bool>>? filter = null;
        if (!string.IsNullOrWhiteSpace(request.TransactionType))
            filter = t => t.TransactionsType.TransactionName == request.TransactionType;

        Expression<Func<Transaction, TransactionDto>> selector = t => new TransactionDto
        {
            TransactionId = t.TransactionId,
            TransactionDate = t.TransactionDate,
            TransactionType = t.TransactionsType.TransactionName,
            TransactionTypeId = t.TransactionTypeId,
            RequestId = t.RequestId,
            Description = t.Description
        };

        Func<IQueryable<Transaction>, IOrderedQueryable<Transaction>> orderBy = q =>
            q.OrderByDescending(t => t.TransactionDate).ThenBy(t => t.TransactionId);

        var items = await _repository.SelectListAsync(
            filter: filter,
            orderBy: orderBy,
            selector: selector,
            skip: request.Page * request.Size,
            take: request.Size,
            ct: cancellationToken
        );

        var total = await _repository.CountAsync(filter, cancellationToken);

        return new PageResult<TransactionDto>(items, total, request.Page, request.Size);
    }
}

