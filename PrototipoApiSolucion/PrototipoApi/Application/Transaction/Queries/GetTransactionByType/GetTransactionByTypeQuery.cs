using MediatR;
using PrototipoApi.Models;

public record GetTransactionByTypeQuery(string Type) : IRequest<TransactionDto?>;
