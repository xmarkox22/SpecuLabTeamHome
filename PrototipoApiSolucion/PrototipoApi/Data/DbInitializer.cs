using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(ContextoBaseDatos context)
    {
        if (!context.Buildings.Any())
        {
            var buildings = Seeder.GenerateBuildings(10);
            context.Buildings.AddRange(buildings);
            await context.SaveChangesAsync(); // Para que tengan IDs
        }

        if (!context.Requests.Any())
        {
            var buildings = await context.Buildings.ToListAsync();
            var requests = Seeder.GenerateRequests(20, buildings);
            context.Requests.AddRange(requests);
            await context.SaveChangesAsync();
        }
    }
}
