using MediatR;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PrototipoApi.Application.Requests.Queries.GetRequestByStatus
{
    public class GetRequestByStatusHandler : IRequestHandler<GetRequestByStatusQuery, List<RequestDto>>
    {
        private readonly IRepository<Request> _repository;

        public GetRequestByStatusHandler(IRepository<Request> repository)
        {
            _repository = repository;
        }

        public async Task<List<RequestDto>> Handle(GetRequestByStatusQuery request, CancellationToken cancellationToken)
        {
            var requestDtos = await _repository.SelectListAsync<RequestDto>(
                filter: r => r.Status.StatusType == request.status,
                orderBy: q => q.OrderBy(r => r.RequestId),
                selector: r => new RequestDto
                {
                    RequestId = r.RequestId,
                    BuildingAmount = r.BuildingAmount,
                    MaintenanceAmount = r.MaintenanceAmount,
                    Description = r.Description,
                    StatusId = r.StatusId,
                    StatusType = r.Status.StatusType,
                    BuildingId = r.BuildingId,
                    BuildingStreet = r.Building.Street
                },
                ct: cancellationToken
                );

            return requestDtos;
        }
    }
}
