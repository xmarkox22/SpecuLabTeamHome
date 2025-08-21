using MediatR;
using PrototipoApi.Models;
using PrototipoApi.Entities;
using PrototipoApi.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;


namespace PrototipoApi.Application.ManagementBudget.Queries
{
    public class GetAllManagementBudgetsQueryHandler : IRequestHandler<GetAllManagementBudgetsQuery, IEnumerable<ManagementBudgetDto>>
    {
        private readonly IRepository<Entities.ManagementBudget> _repository;

        public GetAllManagementBudgetsQueryHandler(IRepository<Entities.ManagementBudget> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ManagementBudgetDto>> Handle(GetAllManagementBudgetsQuery request, CancellationToken cancellationToken)
        {
            var budgets = await _repository.GetAllAsync();

            return budgets.Select(b => new ManagementBudgetDto
            {
                ManagementBudgetId = b.ManagementBudgetId,
                CurrentAmount = b.CurrentAmount,
                LastUpdatedDate = b.LastUpdatedDate
            }).ToList();
        }
    }
}

