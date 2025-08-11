using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;
using System.Threading;
using System.Threading.Tasks;

public class GetManagementBudgetByIdHandler : IRequestHandler<GetManagementBudgetByIdQuery, ManagementBudgetDto>
{
    private readonly ContextoBaseDatos _context;

    public GetManagementBudgetByIdHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<ManagementBudgetDto> Handle(GetManagementBudgetByIdQuery request, CancellationToken cancellationToken)
    {
        var budget = await _context.ManagementBudgets
            .FirstOrDefaultAsync(b => b.ManagementBudgetId == request.Id, cancellationToken);

        if (budget == null)
            return null;

        return new ManagementBudgetDto
        {
            ManagementBudgetId = budget.ManagementBudgetId,
            InitialAmount = budget.InitialAmount,
            CurrentAmount = budget.CurrentAmount,
            LastUpdatedDate = budget.LastUpdatedDate
        };
    }
}



