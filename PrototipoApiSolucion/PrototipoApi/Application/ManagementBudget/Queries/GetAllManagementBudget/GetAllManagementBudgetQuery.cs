using MediatR;
using PrototipoApi.Models;
using System.Collections.Generic;

namespace PrototipoApi.Application.ManagementBudget.Queries
{
    public class GetAllManagementBudgetsQuery : IRequest<IEnumerable<ManagementBudgetDto>>
    {
    }
}

