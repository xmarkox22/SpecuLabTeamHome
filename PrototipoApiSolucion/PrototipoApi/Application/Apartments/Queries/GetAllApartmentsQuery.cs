using MediatR;
using PrototipoApi.Models;
using System.Collections.Generic;

namespace PrototipoApi.Application.Apartments.Queries
{
    public class GetAllApartmentsQuery : IRequest<List<ApartmentDto>>
    {
        public int Page { get; set; } = 1;
        public int Size { get; set; } = 10;
        public string? OrderBy { get; set; } = "CreatedDate";
        public bool Desc { get; set; } = true;

        public GetAllApartmentsQuery(int page = 1, int size = 10, string? orderBy = "CreatedDate", bool desc = true)
        {
            Page = page;
            Size = size;
            OrderBy = orderBy;
            Desc = desc;
        }
    }
}
