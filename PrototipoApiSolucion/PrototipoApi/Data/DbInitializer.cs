using PrototipoApi.BaseDatos;
using Microsoft.EntityFrameworkCore;
using PrototipoApi.Entities;

namespace PrototipoApi.Data
{
    public static class DbInitializer
    {
        public static async Task SeedAsync(ContextoBaseDatos context)
        {
            if (!context.Statuses.Any())
            {
                var statuses = Seeder.GenerateStatuses();
                context.Statuses.AddRange(statuses);
            }

            if (!context.Buildings.Any())
            {
                var buildings = Seeder.GenerateBuildings(10);
                context.Buildings.AddRange(buildings);
            }

            await context.SaveChangesAsync();

            if (!context.Requests.Any())
            {
                var statuses = await context.Statuses.ToListAsync();
                var buildings = await context.Buildings.ToListAsync();
                var requests = Seeder.GenerateRequests(20, buildings, statuses);
                context.Requests.AddRange(requests);
                await context.SaveChangesAsync();
            }

            // Seeding para ManagementBudget: solo una línea
            if (!context.ManagementBudget.Any())
            {
                context.ManagementBudget.Add(new ManagementBudget
                {
                    InitialAmount = 100000000,
                    CurrentAmount = 80000000,
                    LastUpdatedDate = DateTime.UtcNow
                });
                await context.SaveChangesAsync();
            }
        }
    }
}

