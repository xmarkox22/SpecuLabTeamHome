using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAllStatusHandler : IRequestHandler<GetAllStatusQuery, List<StatusDto>>
{
    private readonly ContextoBaseDatos _context;

    public GetAllStatusHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<List<StatusDto>> Handle(GetAllStatusQuery request, CancellationToken cancellationToken)
    {
        var statuses = await _context.Statuses.ToListAsync(cancellationToken);

        return statuses.Select(s => new StatusDto
        {
            StatusId = s.StatusId,
            StatusType = s.StatusType,
            Description = s.Description
        }).ToList();
    }
}

