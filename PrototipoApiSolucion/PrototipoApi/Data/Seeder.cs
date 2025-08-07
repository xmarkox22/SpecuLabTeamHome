using Bogus;
using PrototipoApi.Entities;

namespace PrototipoApi.Data
{
    public static class Seeder
    {
        private static readonly string[] StatusTypes = new[]
        {
            "Pendiente", "En revisión", "Aprobado", "Rechazado"
        };

        private static readonly string[] TransactionsTypes = new[]
        {
            "INGRESO", "GASTO"
        };

        
        // 1. Buildings
        public static List<Building> GenerateBuildings(int count)
        {
            var faker = new Faker<Building>()
                .RuleFor(b => b.Street, f => f.Address.StreetAddress());

            return faker.Generate(count);
        }

        
        // 2. Requests
        public static List<Request> GenerateRequests(int count, List<Building> buildings)
        {
            var requestFaker = new Faker<Request>()
                .RuleFor(r => r.BuildingAmount, f => (double)f.Finance.Amount(50000, 500000))
                .RuleFor(r => r.MaintenanceAmount, f => (double)f.Finance.Amount(5000, 50000))
                .RuleFor(r => r.Description, f => f.Lorem.Sentence(6))
                .RuleFor(r => r.RequestDate, f => f.Date.Past(1))
                .RuleFor(r => r.Building, f => f.PickRandom(buildings))
                .RuleFor(r => r.Status, f => new Status
                {
                 // Asignar un ID único para el estado
                    StatusType = f.PickRandom(StatusTypes),
                    Description = f.Lorem.Sentence(4)
                });

            return requestFaker.Generate(count);
        }

        
        // 3. ManagementBudgets
        public static List<ManagementBudget> GenerateManagementBudgets(int count)
        {
            const double initialAmount = 50000; // Valor fijo para todos los registros
            var faker = new Faker<ManagementBudget>()
                .RuleFor(mb => mb.InitialAmount, f => initialAmount)
                .RuleFor(mb => mb.CurrentAmount, f => initialAmount + (double)f.Finance.Amount(-20000, 40000))
                .RuleFor(mb => mb.LastUpdatedDate, f => f.Date.Recent(30));
            return faker.Generate(count);
        }

        // 4. Transactions
        public static List<Transaction> GenerateTransactions(
            int count,
            List<Request> requests,
            List<ManagementBudget> budgets)
        {
            var transactionFaker = new Faker<Transaction>()
                .RuleFor(t => t.TransactionDate, f => f.Date.Recent(365))
                .RuleFor(t => t.Amount, f => (double)Math.Round(f.Random.Decimal(100, 50000), 2))
                .RuleFor(t => t.Description, f => f.Lorem.Sentence(5))
                .RuleFor(t => t.Request, f => f.PickRandom(requests))
                .RuleFor(t => t.RequestId, (f, t) => t.Request.RequestId)
                .RuleFor(t => t.AssociatedBudget, f => f.PickRandom(budgets))
                .RuleFor(t => t.AssociatedBudgetId, (f, t) => t.AssociatedBudget.ManagementBudgetId)
                .RuleFor(t => t.TransactionsType, f => new TransactionType
                {
                    TransactionName = f.PickRandom(TransactionsTypes)
                });

            return transactionFaker.Generate(count);
        }

    }
}
