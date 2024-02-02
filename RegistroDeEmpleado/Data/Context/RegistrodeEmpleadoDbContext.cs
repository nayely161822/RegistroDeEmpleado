using Microsoft.EntityFrameworkCore;
using RegistroDeEmpleado.Data.Models;

namespace RegistroDeEmpleado.Data.Context
{
    public class RegistrodeEmpleadoDbContext : DbContext, IRegistrodeEmpleadoDbContext
    {
        private readonly IConfiguration config;

        public RegistrodeEmpleadoDbContext(IConfiguration config)
        {
            this.config = config;
        }
        public DbSet<Empleado> Empleados { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(config.GetConnectionString("MSSQL"));
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
