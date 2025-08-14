using FluentValidation;

namespace PrototipoApi.Application.Requests.Queries.GetAllRequests
{
    public class GetAllRequestsQueryValidator : AbstractValidator<GetAllRequestsQuery>
    {
        private static readonly string[] AllowedSort = { "requestid", "requestdate", "status", "amount" };

        public GetAllRequestsQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Size).InclusiveBetween(1, 100);

            RuleFor(x => x.SortBy)
                .NotEmpty()
                .Must(s => AllowedSort.Contains(s!.ToLowerInvariant()))
                .WithMessage("SortBy debe ser uno de: requestId, requestDate, status, amount");

            RuleFor(x => x.Status)
                .MaximumLength(50); // ajusta a tu modelo si aplica
        }
    }
}
