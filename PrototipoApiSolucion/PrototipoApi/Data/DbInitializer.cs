using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Data;

public static class DbInitializer
{
    public static async Task SeedAsync(ContextoBaseDatos context)
    {

        // 1. Buildings

        if (!context.Buildings.Any())
        {
            var buildings = Seeder.GenerateBuildings(10);
            context.Buildings.AddRange(buildings);
            await context.SaveChangesAsync(); // Para que tengan IDs
        }

        // 2. Requests

        if (!context.Requests.Any())
        {
            var buildings = await context.Buildings.ToListAsync();
            var requests = Seeder.GenerateRequests(20, buildings);
            context.Requests.AddRange(requests);
            await context.SaveChangesAsync();
        }

        // Borra todos los registros antiguos de ManagementBudget
        if (context.ManagementBudgets.Any())
        {
            context.ManagementBudgets.RemoveRange(context.ManagementBudgets);
            await context.SaveChangesAsync();
        }

        // Inserta los nuevos registros con el InitialAmount fijo
        var managementBudgets = Seeder.GenerateManagementBudgets(5);
        context.ManagementBudgets.AddRange(managementBudgets);
        await context.SaveChangesAsync();
        // 3. Transactions

        if (!context.Transactions.Any())
        {
            var requests = await context.Requests.ToListAsync();
            var budgets = await context.ManagementBudgets.ToListAsync();
            var transactions = Seeder.GenerateTransactions(100, requests, budgets);
            context.Transactions.AddRange(transactions);
            await context.SaveChangesAsync();
        }
    }
}
