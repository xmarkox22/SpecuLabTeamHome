using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PrototipoApi.Application.Apartments.Commands.CreateApartment
{
    public class CreateApartmentHandler : IRequestHandler<CreateApartmentCommand, ApartmentDto>
    {
        private readonly IRepository<Apartment> _apartments;
        public CreateApartmentHandler(IRepository<Apartment> apartments)
        {
            _apartments = apartments;
        }
        public async Task<ApartmentDto> Handle(CreateApartmentCommand request, CancellationToken cancellationToken)
        {
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
                HasGarage = dto.HasGarage
            };
            await _apartments.AddAsync(entity);
            await _apartments.SaveChangesAsync();
            dto.ApartmentId = entity.ApartmentId;
            return dto;
        }
    }
}
