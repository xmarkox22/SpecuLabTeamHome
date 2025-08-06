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

        public static List<Building> GenerateBuildings(int count)
        {
            var faker = new Faker<Building>()
                .RuleFor(b => b.Street, f => f.Address.StreetAddress());

            return faker.Generate(count);
        }

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
                    StatusType = f.PickRandom(StatusTypes),
                    Description = f.Lorem.Sentence(4)
                });

            return requestFaker.Generate(count);
        }

        public static List<ManagementBudget> GenerateManagementBudgets(int count)
        {
            const double initialAmount = 50000; // Valor fijo para todos los registros
            var faker = new Faker<ManagementBudget>()
                .RuleFor(mb => mb.InitialAmount, f => initialAmount)
                .RuleFor(mb => mb.CurrentAmount, f => initialAmount + (double)f.Finance.Amount(-20000, 40000))
                .RuleFor(mb => mb.LastUpdatedDate, f => f.Date.Recent(30));
            return faker.Generate(count);
        }
    }
}
