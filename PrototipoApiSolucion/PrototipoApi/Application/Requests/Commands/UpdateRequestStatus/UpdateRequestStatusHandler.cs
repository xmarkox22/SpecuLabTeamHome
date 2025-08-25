using MediatR;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PrototipoApi.Application.Requests.Commands.UpdateRequestStatus
{
    public class UpdateRequestStatusHandler : IRequestHandler<UpdateRequestStatusCommand, bool>
    {
        private readonly IRepository<Request> _requests;
        private readonly IRepository<Status> _statuses;
        public UpdateRequestStatusHandler(IRepository<Request> requests, IRepository<Status> statuses)
        {
            _requests = requests;
            _statuses = statuses;
        }
        public async Task<bool> Handle(UpdateRequestStatusCommand request, CancellationToken cancellationToken)
        {
            var entity = await _requests.GetByIdAsync(request.RequestId);
            if (entity == null)
                return false;
            var status = await _statuses.GetByIdAsync(request.StatusId);
            if (status == null)
                return false;
            int oldStatusId = entity.StatusId;
            entity.StatusId = request.StatusId;
            await _requests.UpdateAsync(entity, () =>
            {
                entity.StatusHistory.Add(new RequestStatusHistory
                {
                    RequestId = entity.RequestId,
                    OldStatusId = oldStatusId,
                    NewStatusId = request.StatusId,
                    ChangeDate = DateTime.UtcNow,
                    Comment = "Cambio de estado vía API"
                });
            });
            await _requests.SaveChangesAsync();
            return true;
        }
    }
}
