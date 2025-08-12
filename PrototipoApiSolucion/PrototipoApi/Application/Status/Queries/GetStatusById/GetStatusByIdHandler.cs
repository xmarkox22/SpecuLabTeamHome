using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

public class GetStatusByIdHandler : IRequestHandler<GetStatusByIdQuery, StatusDto?>
{
    private readonly IRepository<Status> _repository;

    public GetStatusByIdHandler(IRepository<Status> repository)
    {
        _repository = repository;
    }

    public async Task<StatusDto?> Handle(GetStatusByIdQuery request, CancellationToken cancellationToken)
    {
        var status = await _repository.GetByIdAsync(request.Id);

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

