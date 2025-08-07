using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;

namespace PrototipoApi.Application.Requests.Queries.GetRequestByStatus
{
    public class GetRequestByStatusHandler : IRequestHandler<GetRequestByStatusQuery, List<RequestDto>>
    {
        private readonly ContextoBaseDatos _context;

        public GetRequestByStatusHandler(ContextoBaseDatos context)
        {
            _context = context;
        }

        public async Task<List<RequestDto>> Handle(GetRequestByStatusQuery request, CancellationToken cancellationToken)
        {
            var requests = await _context.Requests
                .Include(r => r.Status)
                .Include(r => r.Building)
                .Where(r => r.Status.StatusType == request.status)
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
}
