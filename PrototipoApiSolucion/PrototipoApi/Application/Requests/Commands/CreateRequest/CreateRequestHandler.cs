using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;
using Request = PrototipoApi.Entities.Request;
using PrototipoApi.Application.Requests.Commands.CreateRequest;
using PrototipoApi.Services;

// Handler que usa CreateRequestDto, pero mantiene el patrón MediatR con CreateRequestCommand
public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, RequestDto>
{
    private readonly IRepository<Request> _requests;
    private readonly IRepository<Building> _buildings;
    private readonly IRepository<Status> _statuses;
    private readonly IExternalBuildingService _externalBuildingService;

    public CreateRequestCommandHandler(
        IRepository<Request> requests,
        IRepository<Building> buildings,
        IRepository<Status> statuses,
        IExternalBuildingService externalBuildingService)
    {
        _requests = requests;
        _buildings = buildings;
        _statuses = statuses;
        _externalBuildingService = externalBuildingService;
    }

    public async Task<RequestDto> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        // Buscar BuildingId a partir del código
        var building = await _buildings.GetOneAsync(b => b.BuildingCode == dto.BuildingCode);
        if (building == null)
        {
            // Llama a la API externa y crea el edificio si no existe
            building = await _externalBuildingService.GetBuildingByCodeAsync(dto.BuildingCode);
            if (building == null)
                throw new Exception($"No se encontró el edificio con código {dto.BuildingCode} en la API externa.");
            await _buildings.AddAsync(building);
            await _buildings.SaveChangesAsync();
        }
        // Siempre usar 'Recibido' como estado por defecto
        var status = await _statuses.GetOneAsync(s => s.StatusType == "Recibido");
        if (status == null)
            throw new Exception("El estado 'Recibido' no existe.");

        var entity = new Request
        {
            Description = dto.Description,
            BuildingAmount = dto.BuildingAmount,
            MaintenanceAmount = dto.MaintenanceAmount,
            BuildingId = building.BuildingId,
            StatusId = status.StatusId,
            RequestDate = DateTime.UtcNow
        };

        await _requests.AddAsync(entity);
        await _requests.SaveChangesAsync();

        // Proyección directa a DTO
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
