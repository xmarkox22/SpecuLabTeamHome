using MediatR;
using PrototipoApi.Models;

public record GetStatusByIdQuery(int Id) : IRequest<StatusDto?>;

