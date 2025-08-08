using MediatR;
using PrototipoApi.Models;
using System;

public record CreateTransactionCommand(
    DateTime TransactionDate,
    int TransactionTypeId,
    int RequestId
// int? ManagementBudgetId // Descomenta si lo usas
) : IRequest<TransactionDto>;

