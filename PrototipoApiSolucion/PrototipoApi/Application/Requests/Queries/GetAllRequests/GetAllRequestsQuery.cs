using MediatR;
using PrototipoApi.Application.Common;
using PrototipoApi.Models;

public record GetAllRequestsQuery(
    int Page = 0,
    int Size = 20,
    string? Status = null,
    string? SortBy = "requestDate",
    bool Desc = true
) : IRequest<PageResult<RequestDto>>;

