using Microsoft.EntityFrameworkCore;
using PrototipoApi.Entities;
using PrototipoApi.Models;

namespace PrototipoApi.BaseDatos
{
    public class ContextoBaseDatos : DbContext
    {
        public ContextoBaseDatos(DbContextOptions<ContextoBaseDatos> options) : base(options)
        {

        }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<ManagementBudget> ManagementBudgets { get; set; } = default!;
        public DbSet<Transaction> Transactions { get; set; } = default!;
        public DbSet<TransactionType> TransactionsTypes { get; set; } = default!;
        public DbSet<Apartment> Apartments { get; set; } = default!;
    }
}
