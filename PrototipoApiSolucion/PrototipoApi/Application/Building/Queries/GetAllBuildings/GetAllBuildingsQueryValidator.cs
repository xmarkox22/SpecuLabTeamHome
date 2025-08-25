using FluentValidation;

namespace PrototipoApi.Application.Building.Queries.GetAllBuildings
{
    public class GetAllBuildingsQueryValidator : AbstractValidator<GetAllBuildingsQuery>
    {
        public GetAllBuildingsQueryValidator()
        {
            RuleFor(x => x.Page).GreaterThan(0);
            RuleFor(x => x.Size).GreaterThan(0).LessThanOrEqualTo(100);
            RuleFor(x => x.FloorCount).GreaterThanOrEqualTo(0);
        }
    }
}
