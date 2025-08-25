using MediatR;

namespace PrototipoApi.Application.Requests.Commands.UpdateRequestStatus
{
    public record UpdateRequestStatusCommand(int RequestId, int StatusId) : IRequest<bool>;
}
