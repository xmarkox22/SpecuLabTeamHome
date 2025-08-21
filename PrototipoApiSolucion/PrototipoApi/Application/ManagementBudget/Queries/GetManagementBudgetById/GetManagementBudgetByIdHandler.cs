using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Threading;
using System.Threading.Tasks;

public class GetManagementBudgetByIdHandler : IRequestHandler<GetManagementBudgetByIdQuery, ManagementBudgetDto>
{
    private readonly IRepository<ManagementBudget> _repository;

    public GetManagementBudgetByIdHandler(IRepository<ManagementBudget> repository)
    {
        _repository = repository;
    }

    public async Task<ManagementBudgetDto> Handle(GetManagementBudgetByIdQuery request, CancellationToken cancellationToken)
    {
        var budget = await _repository.GetByIdAsync(request.Id);

        if (budget == null)
            return null;

        return new ManagementBudgetDto
        {
            ManagementBudgetId = budget.ManagementBudgetId,
            CurrentAmount = budget.CurrentAmount,
            LastUpdatedDate = budget.LastUpdatedDate
        };
    }
}



