using MediatR;
using PrototipoApi.Models;

namespace PrototipoApi.Application.Apartments.Queries.GetApartmentById
{
    public class GetApartmentByIdQuery : IRequest<ApartmentDto?>
    {
        public int ApartmentId { get; }
        public GetApartmentByIdQuery(int apartmentId)
        {
            ApartmentId = apartmentId;
        }
    }
}
