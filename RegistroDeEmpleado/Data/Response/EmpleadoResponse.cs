using RegistroDeEmpleado.Data.Request;

namespace RegistroDeEmpleado.Data.Response
{
    public class EmpleadoResponse
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Seguro { get; set; } = null!;

        public EmpleadoRequest ToRequest(){
            return new EmpleadoRequest
            {
                Id = Id,
                Nombre = Nombre,
                Telefono = Telefono,
                Direccion = Direccion,
                Cedula = Cedula,
                Seguro = Seguro
            };
        }
    }
}
