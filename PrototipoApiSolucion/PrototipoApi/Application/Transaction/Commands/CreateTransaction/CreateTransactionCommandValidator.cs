using FluentValidation;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;

public class CreateTransactionCommandValidator : AbstractValidator<CreateTransactionCommand>
{
    public CreateTransactionCommandValidator(IRepository<TransactionType> transactionTypes, IRepository<Request> requests)
    {
        RuleFor(x => x.TransactionDate)
            .LessThanOrEqualTo(DateTime.Now).WithMessage("La fecha de la transacción no puede ser futura.");

        RuleFor(x => x.TransactionTypeId)
            .GreaterThan(0)
            .MustAsync(async (id, ct) => await transactionTypes.AnyAsync(t => t.TransactionTypeId == id, ct))
            .WithMessage("El tipo de transacción especificado no existe.");

        RuleFor(x => x.RequestId)
            .GreaterThan(0)
            .MustAsync(async (id, ct) => await requests.AnyAsync(r => r.RequestId == id, ct))
            .WithMessage("La solicitud especificada no existe.");
    }
}
