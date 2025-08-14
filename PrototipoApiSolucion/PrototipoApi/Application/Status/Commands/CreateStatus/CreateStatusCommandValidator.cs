using FluentValidation;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;

public class CreateStatusCommandValidator : FluentValidation.AbstractValidator<CreateStatusCommand>
{
    public CreateStatusCommandValidator(IRepository<Status> statuses)
    {
        RuleFor(x => x.StatusType)
            .NotEmpty().WithMessage("El tipo de estado es obligatorio.")
            .MaximumLength(100).WithMessage("El tipo de estado no puede exceder 100 caracteres.");

        RuleFor(x => x.Description)
            .MaximumLength(500).WithMessage("La descripción no puede exceder 500 caracteres.");

        RuleFor(x => x.StatusType)
            .MustAsync(async (statusType, ct) => !await statuses.AnyAsync(s => s.StatusType == statusType, ct))
            .WithMessage("Ya existe un estado con este tipo.");
    }
}
