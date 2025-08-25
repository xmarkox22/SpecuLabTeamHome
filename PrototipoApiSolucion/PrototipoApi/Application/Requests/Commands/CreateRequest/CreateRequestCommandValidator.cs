using FluentValidation;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;

namespace PrototipoApi.Application.Requests.Commands.CreateRequest
{
    public class CreateRequestCommandValidator : AbstractValidator<CreateRequestCommand>
    {
        public CreateRequestCommandValidator(IRepository<PrototipoApi.Entities.Building> buildings, IRepository<PrototipoApi.Entities.Status> statuses)
        {
            RuleFor(x => x.Dto.Description)
                .NotEmpty().MaximumLength(500);

            RuleFor(x => x.Dto.BuildingAmount).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Dto.MaintenanceAmount).GreaterThanOrEqualTo(0);

            RuleFor(x => x.Dto)
                .Must(d => d.BuildingAmount + d.MaintenanceAmount > 0)
                .WithMessage("El importe total debe ser > 0.");

            //RuleFor(x => x.Dto.BuildingId)
            //    .GreaterThan(0)
            //    .MustAsync(async (id, ct) => await buildings.AnyAsync(b => b.BuildingId == id, ct))
            //    .WithMessage("El edificio especificado no existe.");

            //RuleFor(x => x.Dto.StatusId)
            //    .GreaterThan(0)
            //    .MustAsync(async (id, ct) => await statuses.AnyAsync(s => s.StatusId == id, ct))
            //    .WithMessage("El estado especificado no existe.");
        }
    }
}
