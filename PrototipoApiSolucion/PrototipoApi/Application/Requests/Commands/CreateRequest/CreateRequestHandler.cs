using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.Application.Requests.Commands.UpdateRequest;
using PrototipoApi.Application.Requests.Commands.CreateRequest;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using System.Threading;
using System.Threading.Tasks;

public class CreateRequestCommandHandler : IRequestHandler<CreateRequestCommand, RequestDto>
{
    private readonly ContextoBaseDatos _context;

    public CreateRequestCommandHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<RequestDto> Handle(CreateRequestCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;

        // Validaciones
        var buildingExists = await _context.Buildings.AnyAsync(b => b.BuildingId == dto.BuildingId, cancellationToken);
        if (!buildingExists)
            throw new Exception("El edificio especificado no existe.");

        var statusExists = await _context.Statuses.AnyAsync(s => s.StatusId == dto.StatusId, cancellationToken);
        if (!statusExists)
            throw new Exception("El estado especificado no existe.");

        // Crear la entidad
        var r = new Request
        {
            Description = dto.Description,
            RequestDate = DateTime.UtcNow,
            BuildingAmount = dto.BuildingAmount,
            MaintenanceAmount = dto.MaintenanceAmount,
            StatusId = dto.StatusId,
            BuildingId = dto.BuildingId
        };

        _context.Requests.Add(r);
        await _context.SaveChangesAsync(cancellationToken);

        // Obtener datos relacionados
        var status = await _context.Statuses.FindAsync(new object[] { r.StatusId }, cancellationToken);
        var building = await _context.Buildings.FindAsync(new object[] { r.BuildingId }, cancellationToken);

        // Mapear a DTO de salida
        return new RequestDto
        {
            RequestId = r.RequestId,
            BuildingAmount = r.BuildingAmount,
            MaintenanceAmount = r.MaintenanceAmount,
            Description = r.Description,
            StatusId = r.StatusId,
            StatusType = status?.StatusType ?? "",
            BuildingId = r.BuildingId,
            BuildingStreet = building?.Street ?? ""
        };
    }
}
