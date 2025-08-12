using MediatR;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

public class CreateStatusHandler : IRequestHandler<CreateStatusCommand, StatusDto>
{
    private readonly IRepository<Status> _repository;

    public CreateStatusHandler(IRepository<Status> repository)
    {
        _repository = repository;
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

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return new StatusDto
        {
            StatusId = entity.StatusId,
            StatusType = entity.StatusType,
            Description = entity.Description
        };
    }
}

