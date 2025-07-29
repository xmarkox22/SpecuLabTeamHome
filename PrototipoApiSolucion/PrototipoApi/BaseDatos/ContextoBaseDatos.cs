namespace PrototipoApi.BaseDatos
{
    public class ContextoBaseDatos : DbContext
    {
        public ContextoBaseDatos(DbContextOptions<ContextoBaseDatos> options) : base(options) 
        {

        }
        public DbSet<> MyProperty {  get; set; } //Dentro del Db set ponemos la clase. En MYProperty ponemos el nombre que queremos para la base de datos


    }
}
