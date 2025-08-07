using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;

public class GetAllRequestsHandler : IRequestHandler<GetAllRequestsQuery, List<RequestDto>>
{
    private readonly ContextoBaseDatos _context;

    public GetAllRequestsHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<List<RequestDto>> Handle(GetAllRequestsQuery request, CancellationToken cancellationToken)
    {
        var requests = await _context.Requests
        .Include(r => r.Status)
        .Include(r => r.Building)
        .ToListAsync();

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