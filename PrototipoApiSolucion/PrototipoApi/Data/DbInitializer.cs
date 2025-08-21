using Microsoft.EntityFrameworkCore;
using PrototipoApi.BaseDatos;
using PrototipoApi.Data;
using PrototipoApi.Entities;

public static class DbInitializer
{
    public static async Task SeedAsync(ContextoBaseDatos context)
    {
        // 1. Buildings
        if (!context.Buildings.Any())
        {
            var buildings = Seeder.GenerateBuildings(20);
            context.Buildings.AddRange(buildings);
            await context.SaveChangesAsync();
        }

        // 2. Requests
        //if (!context.Requests.Any())
        //{
        //    var buildings = await context.Buildings.ToListAsync();
        //    var requests = Seeder.GenerateRequests(40, buildings);
        //    context.Requests.AddRange(requests);
        //    await context.SaveChangesAsync();
        //}

        // 3. Transactions (must come before ManagementBudgets)
        if (!context.Transactions.Any())
        {
            var requests = await context.Requests.ToListAsync();
            var transactions = Seeder.GenerateTransactions(100, requests, new List<ManagementBudget>());
            context.Transactions.AddRange(transactions);
            await context.SaveChangesAsync();
        }

        // 4. ManagementBudgets (must reference existing Transactions)
        if (!context.ManagementBudgets.Any())
        {
            var transactions = await context.Transactions.ToListAsync();
            var managementBudgets = Seeder.GenerateManagementBudgets(5);
            // Assign a valid TransactionId to each ManagementBudget
            for (int i = 0; i < managementBudgets.Count; i++)
            {
                var transaction = transactions.ElementAtOrDefault(i % transactions.Count);
                if (transaction != null)
                {
                    managementBudgets[i].TransactionId = transaction.TransactionId;
                    managementBudgets[i].Transaction = transaction;
                }
            }
            context.ManagementBudgets.AddRange(managementBudgets);
            await context.SaveChangesAsync();
        }
    }
}
