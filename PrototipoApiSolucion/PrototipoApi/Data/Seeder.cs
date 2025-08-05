using Bogus;
using PrototipoApi.Entities;

public class Seeder
{
    public static List<Status> GenerateStatuses()
    {
        return new List<Status>
        {
            new Status { StatusType = "Pendiente", Description = "Esperando revisión" },
            new Status { StatusType = "En revisión", Description = "Actualmente evaluándose" },
            new Status { StatusType = "Aprobado", Description = "Aprobada por el comité" },
            new Status { StatusType = "Rechazado", Description = "No cumple los requisitos" }
        };
    }

    public static List<Building> GenerateBuildings(int count)
    {
        var faker = new Faker<Building>()
            .RuleFor(b => b.Street, f => f.Address.StreetAddress());

        return faker.Generate(count);
    }

    public static List<Request> GenerateRequests(int count, List<Building> buildings, List<Status> statuses)
    {
        var faker = new Faker<Request>()
            .RuleFor(r => r.BuildingAmount, f => (double)f.Finance.Amount(50000, 500000))
            .RuleFor(r => r.MaintenanceAmount, f => (double)f.Finance.Amount(5000, 50000))
            .RuleFor(r => r.Description, f => f.Lorem.Sentence(6))
            .RuleFor(r => r.RequestDate, f => f.Date.Past(1))
            .RuleFor(r => r.Building, f => f.PickRandom(buildings))
            .RuleFor(r => r.Status, f => f.PickRandom(statuses));

        return faker.Generate(count);
    }
}
