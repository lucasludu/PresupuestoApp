namespace MiPresupuestoApp.Models.DTO
{
    public class UserUpdateDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }

        public UserUpdateDto()
        {
            
        }

        public UserUpdateDto(string nombre, string apellido, string correo) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correo = correo;
        }

    }
}
