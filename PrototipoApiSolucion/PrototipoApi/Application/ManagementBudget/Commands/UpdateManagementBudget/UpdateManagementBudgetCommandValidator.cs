using FluentValidation;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;

public class UpdateManagementBudgetCommandValidator : AbstractValidator<UpdateManagementBudgetCommand>
{
    public UpdateManagementBudgetCommandValidator(IRepository<ManagementBudget> budgets)
    {
        RuleFor(x => x.ManagementBudgetId)
            .GreaterThan(0)
            .MustAsync(async (id, ct) => await budgets.AnyAsync(b => b.ManagementBudgetId == id, ct))
            .WithMessage("El presupuesto especificado no existe.");

        RuleFor(x => x.CurrentAmount)
            .GreaterThanOrEqualTo(0).WithMessage("El monto debe ser mayor o igual a cero.");

        RuleFor(x => x.LastUpdatedDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de actualización no puede ser futura.");
    }
}
