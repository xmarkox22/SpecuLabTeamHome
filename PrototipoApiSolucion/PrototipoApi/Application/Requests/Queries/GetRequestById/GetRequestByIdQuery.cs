using MediatR;
using PrototipoApi.Models;

namespace PrototipoApi.Application.Requests.Queries.GetRequestById;
public record GetRequestByIdQuery(int id) : IRequest<RequestDto>;