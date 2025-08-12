using MediatR;
using PrototipoApi.Models;

public record UpdateManagementBudgetCommand(
    int ManagementBudgetId,
    double CurrentAmount,
    DateTime LastUpdatedDate
) : IRequest<ManagementBudgetDto?>;


