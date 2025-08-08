using MediatR;
using PrototipoApi.Models;

public record GetTransactionByIdQuery(int Id) : IRequest<TransactionDto?>;

