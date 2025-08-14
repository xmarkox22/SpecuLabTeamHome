using FluentValidation;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;

namespace PrototipoApi.Application.Requests.Commands.UpdateRequest
{
    public class UpdateRequestValidator : AbstractValidator<UpdateRequestCommand>
    {
        public UpdateRequestValidator(IRepository<Request> requests)
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .MustAsync(async (id, ct) => await requests.AnyAsync(r => r.RequestId == id, ct))
                .WithMessage("La solicitud especificada no existe.");

            RuleFor(x => x.Dto.MaintenanceAmount)
                .GreaterThanOrEqualTo(0)
                .WithMessage("El monto de mantenimiento debe ser mayor o igual a cero.");
        }
    }
}
