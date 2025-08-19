using FluentValidation;

public class GetAllTransactionsQueryValidator : AbstractValidator<GetAllTransactionsQuery>
{
    public GetAllTransactionsQueryValidator()
    {
        RuleFor(x => x.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("La página debe ser mayor o igual a 1.");
    }
}
