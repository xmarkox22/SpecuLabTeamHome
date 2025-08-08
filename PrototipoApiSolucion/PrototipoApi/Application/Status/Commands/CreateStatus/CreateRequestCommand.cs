using MediatR;
using PrototipoApi.Models;

public record CreateStatusCommand(string StatusType, string? Description) : IRequest<StatusDto>;

