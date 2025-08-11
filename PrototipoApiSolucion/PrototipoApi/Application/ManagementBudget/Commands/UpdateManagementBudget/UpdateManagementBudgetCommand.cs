using MediatR;
using PrototipoApi.Models;

public record UpdateManagementBudgetCommand(
    int ManagementBudgetId,
    double InitialAmount,
    double CurrentAmount,
    DateTime LastUpdatedDate
) : IRequest<ManagementBudgetDto?>;

