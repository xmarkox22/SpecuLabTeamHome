using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;
using PrototipoApi.Application.Requests.Queries.GetRequestById;

public class GetRequestsByIdHandler : IRequestHandler<GetRequestByIdQuery, RequestDto>
{
    private readonly ContextoBaseDatos _context;

    public GetRequestsByIdHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<RequestDto> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var requestDto = await _context.Requests
            .Include(r => r.Status)
            .Include(r => r.Building)
            .Where(r => r.RequestId == request.id)
            .Select(r => new RequestDto
            {
                RequestId = r.RequestId,
               BuildingAmount = r.BuildingAmount,
               MaintenanceAmount = r.MaintenanceAmount,
                Description = r.Description,
                StatusId = r.StatusId,
                StatusType = r.Status.StatusType,
                BuildingId = r.BuildingId,
                BuildingStreet = r.Building.Street
            })
            .FirstOrDefaultAsync(cancellationToken);


        return requestDto;
    }
}