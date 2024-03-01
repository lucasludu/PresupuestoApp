namespace MiPresupuestoApp.Models.DTO
{
    public class UserLoginDto
    {
        public string Correo { get; set; }
        public string Password { get; set; }

        public UserLoginDto()
        {
            
        }

        public UserLoginDto(string correo, string password) : this()
        {
            this.Correo = correo;
            this.Password = password;
        }
    }
}
