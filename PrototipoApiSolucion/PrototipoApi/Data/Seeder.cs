using Bogus;
using PrototipoApi.Entities;

namespace PrototipoApi.Data
{
    public static class Seeder
    {
        private static readonly string[] StatusTypes = new[]
        {
            "Recibido", "Pendiente", "Aprobado", "Rechazado"
        };

        private static readonly string[] TransactionsTypes = new[]
        {
            "INGRESO", "GASTO"
        };

        
        // 1. Buildings
        public static List<Building> GenerateBuildings(int count)
        {
            var faker = new Faker<Building>()
                .RuleFor(b => b.BuildingCode, f => f.Random.String2(6, "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ"))
                .RuleFor(b => b.BuildingName, f => f.Company.CompanyName())
                .RuleFor(b => b.Street, f => f.Address.StreetAddress())
                .RuleFor(b => b.District, f => f.Address.City())
                .RuleFor(b => b.CreatedDate, f => f.Date.Past(10))
                .RuleFor(b => b.FloorCount, f => f.Random.Int(1, 20))
                .RuleFor(b => b.YearBuilt, f => f.Date.Past(50).Year);

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
                //.RuleFor(t => t.ManagementBudget, f => f.PickRandom(budgets))
                //.RuleFor(t => t.ManagementBudgetId, (f, t) => t.ManagementBudget.ManagementBudgetId)
                .RuleFor(t => t.TransactionsType, f => new TransactionType
                {
                    TransactionName = f.PickRandom(TransactionsTypes)
                });

            return transactionFaker.Generate(count);
        }

    }
}
