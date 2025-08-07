using MediatR;
using PrototipoApi.Models;

public record GetRequestByStatusQuery(string status) : IRequest<List<RequestDto>>;
