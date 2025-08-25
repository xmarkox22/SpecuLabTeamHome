using MediatR;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PrototipoApi.Application.Status.Commands.UpdateStatus
{
    public class UpdateStatusHandler : IRequestHandler<UpdateStatusCommand, bool>
    {
        private readonly IRepository<PrototipoApi.Entities.Status> _repository;
        public UpdateStatusHandler(IRepository<PrototipoApi.Entities.Status> repository)
        {
            _repository = repository;
        }
        public async Task<bool> Handle(UpdateStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.StatusId);
            if (entity == null)
                return false;
            entity.StatusType = request.StatusType;
            entity.Description = request.Description ?? string.Empty;
            entity.UpdatedAt = DateTime.UtcNow;
            await _repository.UpdateAsync(entity);
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
