using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using PrototipoApi.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace PrototipoApi.Application.Apartments.Commands.CreateApartment
{
    public class CreateApartmentHandler : IRequestHandler<CreateApartmentCommand, ApartmentDto>
    {
        private readonly IRepository<Apartment> _apartments;
        private readonly ILoguer _loguer;
        public CreateApartmentHandler(IRepository<Apartment> apartments, ILoguer loguer)
        {
            _apartments = apartments;
            _loguer = loguer;
        }
        public async Task<ApartmentDto> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
            _loguer.LogInfo("Creando nuevo apartamento desde handler");
            var dto = request.Dto;
            var entity = new Apartment
            {
                ApartmentCode = dto.ApartmentCode,
                ApartmentDoor = dto.ApartmentDoor,
                ApartmentFloor = dto.ApartmentFloor,
                ApartmentPrice = dto.ApartmentPrice,
                NumberOfRooms = dto.NumberOfRooms,
                NumberOfBathrooms = dto.NumberOfBathrooms,
                BuildingId = dto.BuildingId,
                HasLift = dto.HasLift,
                HasGarage = dto.HasGarage,
                CreatedDate = dto.CreatedDate
            };
            await _apartments.AddAsync(entity);
            await _apartments.SaveChangesAsync();
            dto.ApartmentId = entity.ApartmentId;
            _loguer.LogInfo($"Apartamento creado con id {entity.ApartmentId}");
            return dto;
        }
    }
}
