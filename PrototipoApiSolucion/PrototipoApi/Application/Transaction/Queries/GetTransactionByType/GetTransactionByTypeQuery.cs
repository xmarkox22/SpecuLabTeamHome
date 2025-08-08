using MediatR;
using PrototipoApi.Models;
using System.Collections.Generic;

public record GetTransactionByTypeQuery(string Type) : IRequest<List<TransactionDto>>;
