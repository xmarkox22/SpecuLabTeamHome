using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace PrototipoApi.Application.Apartments.Queries.GetAllApartments
{
    public class GetAllApartmentsHandler : IRequestHandler<GetAllApartmentsQuery, List<ApartmentDto>>
    {
        private readonly IRepository<Apartment> _apartments;
        public GetAllApartmentsHandler(IRepository<Apartment> apartments)
        {
            _apartments = apartments;
        }
        public async Task<List<ApartmentDto>> Handle(GetAllApartmentsQuery request, CancellationToken cancellationToken)
        {
            Func<IQueryable<Apartment>, IOrderedQueryable<Apartment>>? orderBy = null;
            if (!string.IsNullOrEmpty(request.OrderBy))
            {
                if (request.OrderBy.Equals("CreatedDate", StringComparison.OrdinalIgnoreCase))
                {
                    orderBy = q => request.Desc ? q.OrderByDescending(a => a.CreatedDate) : q.OrderBy(a => a.CreatedDate);
                }
                // Puedes agregar más opciones de ordenación aquí si lo necesitas
            }

            int skip = (request.Page - 1) * request.Size;
            int take = request.Size;

            var result = await _apartments.SelectListAsync(
                null,
                orderBy,
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
                    HasGarage = a.HasGarage,
                    CreatedDate = a.CreatedDate
                },
                skip,
                take,
                cancellationToken
            );
            return result.ToList();
        }
    }
}
