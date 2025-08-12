using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;    
using PrototipoApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

public class GetAllStatusHandler : IRequestHandler<GetAllStatusQuery, List<StatusDto>>
{
    private readonly IRepository<Status> _repository;


    public GetAllStatusHandler(IRepository<Status> repository)
    {
        _repository = repository;
    }

    public async Task<List<StatusDto>> Handle(GetAllStatusQuery request, CancellationToken cancellationToken)
    {
        var statuses = await _repository.GetAllAsync();

        return statuses.Select(s => new StatusDto
        {
            StatusId = s.StatusId,
            StatusType = s.StatusType,
            Description = s.Description
        }).ToList();
    }
}

