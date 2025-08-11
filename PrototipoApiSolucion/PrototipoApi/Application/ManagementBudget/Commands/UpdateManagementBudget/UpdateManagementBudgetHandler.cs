using MediatR;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Models;
using System.Threading;
using System.Threading.Tasks;

public class UpdateManagementBudgetHandler : IRequestHandler<UpdateManagementBudgetCommand, ManagementBudgetDto?>
{
    private readonly ContextoBaseDatos _context;

    public UpdateManagementBudgetHandler(ContextoBaseDatos context)
    {
        _context = context;
    }

    public async Task<ManagementBudgetDto?> Handle(UpdateManagementBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = await _context.ManagementBudgets
            .FirstOrDefaultAsync(mb => mb.ManagementBudgetId == request.ManagementBudgetId, cancellationToken);

        if (budget == null)
            return null;

        budget.InitialAmount = request.InitialAmount;
        budget.CurrentAmount = request.CurrentAmount;
        budget.LastUpdatedDate = request.LastUpdatedDate;

        await _context.SaveChangesAsync(cancellationToken);

        return new ManagementBudgetDto
        {
            ManagementBudgetId = budget.ManagementBudgetId,
            InitialAmount = budget.InitialAmount,
            CurrentAmount = budget.CurrentAmount,
            LastUpdatedDate = budget.LastUpdatedDate
        };
    }
}

