using RegistroDeEmpleado.Data.Request;
using RegistroDeEmpleado.Data.Response;

namespace RegistroDeEmpleado.Data.Services
{
    public interface IEmpleadoServices
    {
        Task<Result<List<EmpleadoResponse>>> Consultar(string filtro);
        Task<Result> Crear(EmpleadoRequest request);
        Task<Result> Eliminar(EmpleadoRequest request);
        Task<Result> Modificar(EmpleadoRequest request);
    }
}