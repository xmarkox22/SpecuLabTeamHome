using MediatR;
using PrototipoApi.Models;

public record UpdateManagementBudgetCommand : IRequest<UpdateManagementBudgetDto>, IBaseRequest, IEquatable<UpdateManagementBudgetCommand>
{
    public int ManagementBudgetId { get; init; } // Agregado para corregir CS1061
    public double CurrentAmount { get; init; }
    public DateTime LastUpdatedDate { get; init; }
}

