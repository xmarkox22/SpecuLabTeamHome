using MediatR;
using PrototipoApi.Models;

public record GetManagementBudgetByIdQuery(int Id) : IRequest<ManagementBudgetDto>;



