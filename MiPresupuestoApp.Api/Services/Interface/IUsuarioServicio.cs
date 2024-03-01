using MiPresupuestoApp.Models.DTO;

namespace MiPresupuestoApp.Api.Services.Interface
{
    public interface IUsuarioServicio
    {
        UserDto Register (UserRegisterDto userRegisterDto, string password);
        UserDto Login (UserLoginDto userLoginDto);
        string GetToken(UserDto userDto);
    }
}
