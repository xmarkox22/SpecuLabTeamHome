using MediatR;
using PrototipoApi.BaseDatos;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;

namespace PrototipoApi.Application.Requests.Commands.UpdateRequest
{
    public class UpdateRequestHandler : IRequestHandler<UpdateRequestCommand, bool>
    {
        private readonly IRepository<Request> _repository;

        public UpdateRequestHandler(IRepository<Request> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _repository.GetByIdAsync(request.Id);

            if (entity == null)
                return false;

            entity.BuildingAmount = request.Dto.BuildingAmount;
            entity.MaintenanceAmount = request.Dto.MaintenanceAmount;

            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
