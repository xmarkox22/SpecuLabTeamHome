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
            .Must(v => new[] { "Pendiente", "Recivido", "Aprobado", "Rechazado" }.Contains(v))
            .WithMessage("El tipo de estado debe ser uno de: Pendiente, En revisión, Aprobado, Rechazado.");
    }
}
