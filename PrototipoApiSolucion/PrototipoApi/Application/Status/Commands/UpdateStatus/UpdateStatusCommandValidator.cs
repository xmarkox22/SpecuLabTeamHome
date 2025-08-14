using FluentValidation;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;

namespace PrototipoApi.Application.Status.Commands.UpdateStatus
{
    public class UpdateStatusCommandValidator : AbstractValidator<UpdateStatusCommand>
    {
        public UpdateStatusCommandValidator(IRepository<PrototipoApi.Entities.Status> statuses)
        {
            RuleFor(x => x.StatusType)
                .NotEmpty().WithMessage("El tipo de estado es obligatorio.")
                .MaximumLength(100).WithMessage("El tipo de estado no puede exceder 100 caracteres.");

            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("La descripción no puede exceder 500 caracteres.");

            RuleFor(x => x.StatusId)
                .GreaterThan(0)
                .MustAsync(async (id, ct) => await statuses.AnyAsync(s => s.StatusId == id, ct))
                .WithMessage("El estado especificado no existe.");
        }
    }
}
