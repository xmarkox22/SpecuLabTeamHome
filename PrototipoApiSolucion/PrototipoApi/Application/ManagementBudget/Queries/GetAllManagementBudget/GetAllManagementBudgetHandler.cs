using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace PrototipoApi.Application.ManagementBudget.Queries
{
    public class GetAllManagementBudgetsQueryHandler : IRequestHandler<GetAllManagementBudgetsQuery, IEnumerable<ManagementBudgetDto>>
    {
        private readonly ContextoBaseDatos _context;

        public GetAllManagementBudgetsQueryHandler(ContextoBaseDatos context)
        {
            _context = context;
        }

        public async Task<IEnumerable<ManagementBudgetDto>> Handle(GetAllManagementBudgetsQuery request, CancellationToken cancellationToken)
        {
            var budgets = await _context.ManagementBudgets
                .ToListAsync(cancellationToken);

            return budgets.Select(b => new ManagementBudgetDto
            {
                ManagementBudgetId = b.ManagementBudgetId,
                InitialAmount = b.InitialAmount,
                CurrentAmount = b.CurrentAmount,
                LastUpdatedDate = b.LastUpdatedDate
            }).ToList();
        }
    }
}

