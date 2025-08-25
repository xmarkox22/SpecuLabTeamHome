using MediatR;
using PrototipoApi.Models;

namespace PrototipoApi.Application.Building.Queries.GetBuildingById
{
    public record GetBuildingByIdQuery(int BuildingId) : IRequest<BuildingDto?>;
}
