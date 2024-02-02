using Microsoft.EntityFrameworkCore;
using RegistroDeEmpleado.Data.Context;
using RegistroDeEmpleado.Data.Models;
using RegistroDeEmpleado.Data.Request;
using RegistroDeEmpleado.Data.Response;

namespace RegistroDeEmpleado.Data.Services
{
    public class Result
    {
        public bool Success  { get; set; }
        public string? Message { get; set; }
    }
    public class Result <T>
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
    public class EmpleadoServices : IEmpleadoServices
    {
        private readonly IRegistrodeEmpleadoDbContext dbContext;

        public EmpleadoServices(IRegistrodeEmpleadoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Result> Crear(EmpleadoRequest request)
        {
            try
            {
                var empleado = Empleado.Crear(request);
                dbContext.Empleados.Add(empleado);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Modificar(EmpleadoRequest request)
        {
            try
            {
                var empleado = await dbContext.Empleados
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (empleado == null)
                    return new Result() { Message = "No se encontro el empleado", Success = true };

                if (empleado.Modificar(request))
                    await dbContext.SaveChangesAsync();

                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result> Eliminar(EmpleadoRequest request)
        {
            try
            {
                var empleado = await dbContext.Empleados
                    .FirstOrDefaultAsync(c => c.Id == request.Id);
                if (empleado == null)
                    return new Result() { Message = "No se encontro el empleado", Success = true };

                dbContext.Empleados.Remove(empleado);
                await dbContext.SaveChangesAsync();
                return new Result() { Message = "Ok", Success = true };
            }
            catch (Exception E)
            {

                return new Result() { Message = E.Message, Success = false };
            }
        }
        public async Task<Result<List<EmpleadoResponse>>> Consultar(string filtro)
        {
            try
            {
                var empleados = await dbContext.Empleados
                    .Where(c =>
                    (c.Nombre + " " + c.Telefono + " " + c.Direccion +
                    " " + c.Cedula + " " + c.Seguro)
                    .ToLower()
                    .Contains(filtro.ToLower()
                    )
                 )
                .Select(c => c.ToResponse())
                .ToListAsync();
                return new Result<List<EmpleadoResponse>>()
                {
                    Message = "Ok",
                    Success = true,
                    Data = empleados
                };
            }
            catch (Exception E)
            {

                return new Result<List<EmpleadoResponse>>
                {
                    Message = E.Message,
                    Success = false
                };
            }
        }
    }
}
