using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.Application.Common;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;
using System.Linq.Expressions;

public class GetAllRequestsHandler : IRequestHandler<GetAllRequestsQuery, PageResult<RequestDto>>
{
    private readonly IRepository<Request> _repository;

    public GetAllRequestsHandler(IRepository<Request> repository)
    {
        _repository = repository;
    }

    public async Task<PageResult<RequestDto>> Handle(GetAllRequestsQuery request, CancellationToken ct)
    {
        // sin filtros por ahora; los añadimos luego si quieres
        Expression<Func<Request, bool>>? filter = null;
        if (!string.IsNullOrWhiteSpace(request.Status))
            filter = r => r.Status.StatusType == request.Status;

        // selector a DTO (sin Include; EF hará los JOIN necesarios)
        Expression<Func<Request, RequestDto>> selector = r => new RequestDto
        {
            RequestId = r.RequestId,
            BuildingAmount = r.BuildingAmount,
            MaintenanceAmount = r.MaintenanceAmount,
            Description = r.Description,
            StatusId = r.StatusId,
            StatusType = r.Status.StatusType,
            BuildingId = r.BuildingId,
            BuildingStreet = r.Building.Street
        };

        // orden estable para paginación (primario + secundario)
        Func<IQueryable<Request>, IOrderedQueryable<Request>> orderBy = q =>
            q.OrderByDescending(r => r.RequestDate).ThenBy(r => r.RequestId);

        var items = await _repository.SelectListAsync(
            filter: filter,
            orderBy: orderBy,
            selector: selector,
            skip: request.Page * request.Size,
            take: request.Size,
            ct: ct
        );

        var total = await _repository.CountAsync(filter, ct);

        return new PageResult<RequestDto>(items, total, request.Page, request.Size);
    }
}