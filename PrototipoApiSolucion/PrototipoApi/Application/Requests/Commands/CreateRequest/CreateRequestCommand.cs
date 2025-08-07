using MediatR;
using PrototipoApi.Models;

public class CreateRequestCommand : IRequest<RequestDto>
{
    public CreateRequestDto Dto { get; set; }
    public CreateRequestCommand(CreateRequestDto dto)
    {
        Dto = dto;
    }
}


