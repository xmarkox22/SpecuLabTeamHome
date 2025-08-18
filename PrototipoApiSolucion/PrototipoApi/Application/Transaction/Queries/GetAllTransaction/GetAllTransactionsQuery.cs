using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Application.Common;
using System.Collections.Generic;

public record GetAllTransactionsQuery(string? TransactionType, int Page, int Size) : IRequest<PageResult<TransactionDto>>;

