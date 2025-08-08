using MediatR;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using System.Threading;
using System.Threading.Tasks;

public class CreateStatusHandler : IRequestHandler<CreateStatusCommand, StatusDto>
{
    private readonly ContextoBaseDatos _context;

    public CreateStatusHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<StatusDto> Handle(CreateStatusCommand request, CancellationToken cancellationToken)
    {
        // Validación simple
        if (string.IsNullOrWhiteSpace(request.StatusType))
            throw new ArgumentException("StatusType no puede estar vacío.");

        var entity = new Status
        {
            StatusType = request.StatusType,
            Description = request.Description
        };

        _context.Statuses.Add(entity);
        await _context.SaveChangesAsync(cancellationToken);

        return new StatusDto
        {
            StatusId = entity.StatusId,
            StatusType = entity.StatusType,
            Description = entity.Description
        };
    }
}

