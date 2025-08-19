using MediatR;
using PrototipoApi.Models;

namespace PrototipoApi.Application.Apartments.Commands
{
    public class CreateApartmentCommand : IRequest<ApartmentDto>
    {
        public ApartmentDto Dto { get; }
        public CreateApartmentCommand(ApartmentDto dto)
        {
            Dto = dto;
        }
    }
}
