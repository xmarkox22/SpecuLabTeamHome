using MediatR;
using PrototipoApi.Models;
using System.Collections.Generic;

public record GetAllStatusQuery() : IRequest<List<StatusDto>>;
