using Microsoft.EntityFrameworkCore;
using RegistroDeEmpleado.Data.Models;

namespace RegistroDeEmpleado.Data.Context
{
    public interface IRegistrodeEmpleadoDbContext
    {
       public DbSet<Empleado> Empleados { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}