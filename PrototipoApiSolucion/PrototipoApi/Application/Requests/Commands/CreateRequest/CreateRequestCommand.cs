using global::PrototipoApi.Models;
using MediatR;
namespace PrototipoApi.Application.Requests.Commands.CreateRequest

{

    public record CreateRequestCommand(CreateRequestDto Dto) : IRequest<RequestDto>;

}


