using MediatR;
using PrototipoApi.Models;
using System.Collections.Generic;

namespace PrototipoApi.Application.Building.Queries.GetAllBuildings
{
    public record GetAllBuildingsQuery(
        int Page = 1,
        int Size = 10,
        int FloorCount = 0
    ) : IRequest<List<BuildingDto>>;
}
