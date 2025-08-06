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
        public DbSet<Request> Requests {  get; set; } 
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Building> Buildings { get; set; }
        public DbSet<PrototipoApi.Entities.ManagementBudget> ManagementBudget { get; set; } = default!;
        public DbSet<PrototipoApi.Entities.Transaction> Transaction { get; set; } = default!;
        public object Transactions { get; internal set; }
        public object ManagementBudgets { get; internal set; }
    }
}
