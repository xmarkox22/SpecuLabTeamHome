using MediatR;
using PrototipoApi.Models;
using System.Collections.Generic;

public record GetAllTransactionsQuery() : IRequest<List<TransactionDto>>;

