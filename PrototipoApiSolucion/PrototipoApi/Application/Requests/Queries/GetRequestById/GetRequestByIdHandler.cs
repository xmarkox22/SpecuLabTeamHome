using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.Application.Requests.Queries.GetRequestById;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;

public class GetRequestsByIdHandler : IRequestHandler<GetRequestByIdQuery, RequestDto>
{
    private readonly IRepository<Request> _repository;

    public GetRequestsByIdHandler(IRepository<Request> repository)
    {
        _repository = repository;
    }

    public async Task<RequestDto> Handle(GetRequestByIdQuery request, CancellationToken cancellationToken)
    {
        var requestDto = await _repository.SelectOneAsync(
            filter: r => r.RequestId == request.id,
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


        return requestDto;
    }
}