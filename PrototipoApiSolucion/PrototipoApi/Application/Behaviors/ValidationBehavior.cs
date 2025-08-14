using MediatR;
using FluentValidation;
namespace PrototipoApi.Application.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : notnull
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators) => _validators = validators;

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken ct)
        {
            if (_validators.Any())
            {
                var ctx = new ValidationContext<TRequest>(request);
                var results = await Task.WhenAll(_validators.Select(v => v.ValidateAsync(ctx, ct)));
                var failures = results.SelectMany(r => r.Errors).Where(f => f is not null).ToList();
                if (failures.Count != 0) throw new ValidationException(failures);
            }
            return await next();
        }
    }

}
