using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

public class UpdateManagementBudgetHandler : IRequestHandler<UpdateManagementBudgetCommand, ManagementBudgetDto?>
{
    private readonly IRepository<ManagementBudget> _repository;

    public UpdateManagementBudgetHandler(IRepository<ManagementBudget> repository)
    {
        _repository = repository;
    }

    public async Task<ManagementBudgetDto?> Handle(UpdateManagementBudgetCommand request, CancellationToken cancellationToken)
    {
        var budget = await _repository.GetByIdAsync(request.ManagementBudgetId);

        if (budget == null)
            return null;

        budget.CurrentAmount = request.CurrentAmount;
        budget.LastUpdatedDate = request.LastUpdatedDate;

        await _repository.UpdateAsync(budget);
        await _repository.SaveChangesAsync();

        return new ManagementBudgetDto
        {
            ManagementBudgetId = budget.ManagementBudgetId,
            CurrentAmount = budget.CurrentAmount,
            LastUpdatedDate = budget.LastUpdatedDate
        };
    }
}


