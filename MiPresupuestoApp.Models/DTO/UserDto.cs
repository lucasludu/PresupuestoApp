namespace MiPresupuestoApp.Models.DTO
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }

        public UserDto()
        {
            
        }

        public UserDto(int id, string nombre, string apellido, string correo) : this()
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correo = correo;
        }
    }
}
