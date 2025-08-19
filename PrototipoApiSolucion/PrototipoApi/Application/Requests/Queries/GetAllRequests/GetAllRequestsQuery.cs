using MediatR;
using PrototipoApi.Models;

public record GetAllRequestsQuery(
    int Page = 1,
    int Size = 20,
    string? Status = null,
    string? SortBy = "requestDate",
    bool Desc = true
) : IRequest<List<RequestDto>>;

