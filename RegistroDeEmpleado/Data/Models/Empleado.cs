using RegistroDeEmpleado.Data.Request;
using RegistroDeEmpleado.Data.Response;
using System.ComponentModel.DataAnnotations;

namespace RegistroDeEmpleado.Data.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Seguro { get; set; } = null!;

        public static Empleado Crear(EmpleadoRequest empleado)
        => new()
        {
            Nombre = empleado.Nombre,
            Telefono = empleado.Telefono,
            Direccion = empleado.Direccion,
            Cedula = empleado.Cedula,
            Seguro = empleado.Seguro
        };
        public bool Modificar(EmpleadoRequest empleado)
        {
            var cambio = false;
            if (Nombre != empleado.Nombre)
            {
                Nombre = empleado.Nombre;
                cambio = true;
            }
            if (Telefono != empleado.Telefono)
            {
                Telefono = empleado.Telefono;
                cambio = true;
            }
            if (Direccion != empleado.Direccion)
            {
                Direccion = empleado.Direccion;
                cambio = true;
            }
            if (Cedula != empleado.Cedula)
            {
                Cedula = empleado.Cedula;
                cambio = true;
            }
            if (Seguro != empleado.Seguro)
            {
                Seguro = empleado.Seguro;
                cambio = true;
            }
            return cambio;
        }
        public EmpleadoResponse ToResponse()
       => new()
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
