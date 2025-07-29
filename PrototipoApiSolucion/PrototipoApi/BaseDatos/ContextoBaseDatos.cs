using Microsoft.EntityFrameworkCore;
using PrototipoApi.Entities;

namespace PrototipoApi.BaseDatos
{
    public class ContextoBaseDatos : DbContext
    {
        public ContextoBaseDatos(DbContextOptions<ContextoBaseDatos> options) : base(options) 
        {

        }
        public DbSet<Request> Requests {  get; set; } 


    }
}
