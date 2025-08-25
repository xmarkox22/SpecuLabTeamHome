using MediatR;
using PrototipoApi.Models;

public record CreateBuildingCommand(BuildingDto Dto) : IRequest<BuildingDto>;
