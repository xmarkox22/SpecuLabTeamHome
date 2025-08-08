using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;
using System.Threading;
using System.Threading.Tasks;

public class GetStatusByIdHandler : IRequestHandler<GetStatusByIdQuery, StatusDto?>
{
    private readonly ContextoBaseDatos _context;

    public GetStatusByIdHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<StatusDto?> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var status = await _context.Statuses
            .FirstOrDefaultAsync(s => s.StatusId == request.Id, cancellationToken);

        if (status == null)
            return null;

        return new StatusDto
        {
            StatusId = status.StatusId,
            StatusType = status.StatusType,
            Description = status.Description
        };
    }
}

