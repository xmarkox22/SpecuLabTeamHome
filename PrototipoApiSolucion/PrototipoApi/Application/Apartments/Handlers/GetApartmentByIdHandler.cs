using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace PrototipoApi.Application.Apartments.Handlers
{
    public class GetApartmentByIdHandler : IRequestHandler<Queries.GetApartmentByIdQuery, ApartmentDto?>
    {
        private readonly IRepository<Apartment> _apartments;
        public GetApartmentByIdHandler(IRepository<Apartment> apartments)
        {
            _apartments = apartments;
        }
        public async Task<ApartmentDto?> Handle(Queries.GetApartmentByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _apartments.SelectOneAsync<ApartmentDto>(
                a => a.ApartmentId == request.ApartmentId,
                a => new ApartmentDto
                {
                    ApartmentId = a.ApartmentId,
                    ApartmentCode = a.ApartmentCode,
                    ApartmentDoor = a.ApartmentDoor,
                    ApartmentFloor = a.ApartmentFloor,
                    ApartmentPrice = a.ApartmentPrice,
                    NumberOfRooms = a.NumberOfRooms,
                    NumberOfBathrooms = a.NumberOfBathrooms,
                    BuildingId = a.BuildingId,
                    HasLift = a.HasLift,
                    HasGarage = a.HasGarage
                },
                cancellationToken
            );
            return result;
        }
    }
}
