namespace RegistroDeEmpleado.Data.Request
{
    public class EmpleadoRequest
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public string Telefono { get; set; } = null!;
        public string Direccion { get; set; } = null!;
        public string Cedula { get; set; } = null!;
        public string Seguro { get; set; } = null!;
    }
}
