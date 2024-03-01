using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiPresupuestoApp.Models.DTO
{
    public class UserRegisterDto
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Password { get; set; }

        public UserRegisterDto()
        {
            
        }

        public UserRegisterDto(string nombre, string apellido, string correo, string password) : this()
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Correo = correo;
            this.Password = password;
        }

    }
}
