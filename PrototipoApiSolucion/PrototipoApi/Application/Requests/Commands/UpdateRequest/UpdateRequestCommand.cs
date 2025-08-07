using global::PrototipoApi.Models;
using MediatR;


namespace PrototipoApi.Application.Requests.Commands.UpdateRequest
{


    namespace PrototipoApi.Application.Requests.Commands.UpdateRequest
    {
        public record UpdateRequestCommand(int Id, UpdateRequestDto Dto) : IRequest<bool>;
    }

}
