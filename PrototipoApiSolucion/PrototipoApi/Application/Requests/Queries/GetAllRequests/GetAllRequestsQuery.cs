using MediatR;
using PrototipoApi.Models;

public record GetAllRequestsQuery() : IRequest<List<RequestDto>>;
