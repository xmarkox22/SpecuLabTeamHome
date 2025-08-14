namespace PrototipoApi.Application.Status.Commands.UpdateStatus
{
    public record UpdateStatusCommand(int StatusId, string StatusType, string? Description);
}
