using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;

public class GetAllRequestsHandler : IRequestHandler<GetAllRequestsQuery, List<RequestDto>>
{
    private readonly IRepository<Request> _repository;

    public GetAllRequestsHandler(IRepository<Request> repository)
    {
        _repository = repository;
    }

    public async Task<List<RequestDto>> Handle(GetAllRequestsQuery request, CancellationToken cancellationToken)
    {
        var requests = await _repository.GetAllAsync(
            orderBy: q => q.OrderBy(r => r.RequestId),
            r => r.Status,
            r => r.Building
        );


        //    Requests
        //.Include(r => r.Status)
        //.Include(r => r.Building)
        //.ToListAsync();

        var requestDtos = requests.Select(r => new RequestDto
        {
            RequestId = r.RequestId,
            BuildingAmount = r.BuildingAmount,
            MaintenanceAmount = r.MaintenanceAmount,
            Description = r.Description,
            StatusId = r.StatusId,
            StatusType = r.Status.StatusType,
            BuildingId = r.BuildingId,
            BuildingStreet = r.Building.Street
        }).ToList();

        return requestDtos;
    }
    }