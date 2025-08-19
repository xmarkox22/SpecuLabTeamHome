using MediatR;
using PrototipoApi.Entities;
using PrototipoApi.Models;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

public class CreateBuildingHandler : IRequestHandler<CreateBuildingCommand, BuildingDto>
{
    private readonly IRepository<Building> _repository;

    public CreateBuildingHandler(IRepository<Building> repository)
    {
        _repository = repository;
    }

    public async Task<BuildingDto> Handle(CreateBuildingCommand request, CancellationToken cancellationToken)
    {
        var dto = request.Dto;
        var entity = new Building
        {
            BuildingCode = dto.BuildingCode,
            BuildingName = dto.BuildingName,
            Price = dto.Price,
            Street = dto.Street,
            District = dto.District,
            CreatedDate = dto.CreatedDate,
            FloorCount = dto.FloorCount,
            YearBuilt = dto.YearBuilt
        };

        await _repository.AddAsync(entity);
        await _repository.SaveChangesAsync();

        return new BuildingDto
        {
            BuildingId = entity.BuildingId,
            BuildingCode = entity.BuildingCode,
            BuildingName = entity.BuildingName,
            Price = entity.Price,
            Street = entity.Street,
            District = entity.District,
            CreatedDate = entity.CreatedDate,
            FloorCount = entity.FloorCount,
            YearBuilt = entity.YearBuilt
        };
    }
}
