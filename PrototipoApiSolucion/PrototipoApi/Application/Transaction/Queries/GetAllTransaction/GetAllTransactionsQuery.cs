using MediatR;
using PrototipoApi.Models;
using System.Collections.Generic;

public record GetAllTransactionsQuery(string? TransactionType, int Page, int Size) : IRequest<List<TransactionDto>>;

