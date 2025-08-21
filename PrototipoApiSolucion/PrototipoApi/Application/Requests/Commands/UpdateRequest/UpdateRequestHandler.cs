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

            // Guardar el estado anterior antes de modificarlo
            int oldStatusId = entity.StatusId;

            entity.MaintenanceAmount = request.Dto.MaintenanceAmount;
            // Supón que aquí también cambias el estado si es necesario
            // entity.StatusId = request.Dto.NewStatusId;

            await _repository.UpdateAsync(entity, () =>
            {
                // Actualiza el historial solo en la entidad (no en la base de datos directamente)
                entity.StatusHistory.Add(new RequestStatusHistory
                {
                    RequestId = entity.RequestId,
                    OldStatusId = oldStatusId,
                    NewStatusId = entity.StatusId,
                    ChangeDate = DateTime.UtcNow,
                    Comment = "Actualización de mantenimiento"
                });
            });

            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
