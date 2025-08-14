using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.Application.Requests.Commands.CreateRequest;
using PrototipoApi.Application.Requests.Commands.UpdateRequest;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Request = PrototipoApi.Entities.Request;

public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, RequestDto>
{
    private readonly IRepository<Request> _requests;

    public CreateRequestCommandHandler(IRepository<Request> requests)
    {
        _requests = requests;
    }

    public async Task<RequestDto> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        // Validaciones
        //var buildingExists = await _context.Buildings.AnyAsync(b => b.BuildingId == dto.BuildingId, cancellationToken);
        //if (!buildingExists)
        //    throw new Exception("El edificio especificado no existe.");

        //var statusExists = await _context.Statuses.AnyAsync(s => s.StatusId == dto.StatusId, cancellationToken);
        //if (!statusExists)
        //    throw new Exception("El estado especificado no existe.");

        var entity = new Request
        {
            Description = dto.Description,
            RequestDate = DateTime.UtcNow,
            BuildingAmount = dto.BuildingAmount,
            MaintenanceAmount = dto.MaintenanceAmount,
            StatusId = dto.StatusId!.Value,
            BuildingId = dto.BuildingId!.Value
        };

        await _requests.AddAsync(entity);
        await _requests.SaveChangesAsync();

        // 2) Proyección directa a DTO
        var created = await _requests.SelectOneAsync<RequestDto>(
            r => r.RequestId == entity.RequestId,
            r => new RequestDto
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
            cancellationToken
        );

        return created!;
    }
}
