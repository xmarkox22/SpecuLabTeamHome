using FluentValidation;
using PrototipoApi.Models;

public class CreateBuildingCommandValidator : AbstractValidator<CreateBuildingCommand>
{
    public CreateBuildingCommandValidator()
    {
        RuleFor(x => x.Dto.BuildingName).NotEmpty().MaximumLength(200);
        RuleFor(x => x.Dto.BuildingCode).NotEmpty().MaximumLength(20);
        RuleFor(x => x.Dto.Price).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Dto.Street).NotEmpty();
        RuleFor(x => x.Dto.District).NotEmpty();
        RuleFor(x => x.Dto.FloorCount).GreaterThanOrEqualTo(0);
        RuleFor(x => x.Dto.YearBuilt).GreaterThan(1800);
    }
}
