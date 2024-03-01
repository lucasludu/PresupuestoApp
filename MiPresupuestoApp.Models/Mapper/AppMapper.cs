using AutoMapper;
using MiPresupuestoApp.Models.DTO;

namespace MiPresupuestoApp.Models.Mapper
{
    public class AppMapper : Profile
    {
        public AppMapper()
        {
            CreateMap<Usuario, UserDto>().ReverseMap();
            CreateMap<Usuario, UserRegisterDto>().ReverseMap();
            CreateMap<Usuario, UserLoginDto>().ReverseMap();
        }
    }
}
