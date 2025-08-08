using MediatR;
using PrototipoApi.BaseDatos;

namespace PrototipoApi.Application.Requests.Commands.UpdateRequest
{
    public class UpdateRequestHandler : IRequestHandler<UpdateRequestCommand, bool>
    {
        private readonly ContextoBaseDatos _context;

        public UpdateRequestHandler(ContextoBaseDatos context)
        {
            _context = context;
        }

        public async Task<bool> Handle(UpdateRequestCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Requests.FindAsync( request.Id , cancellationToken);

            if (entity == null)
                return false;

            entity.MaintenanceAmount = request.Dto.MaintenanceAmount;

            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
