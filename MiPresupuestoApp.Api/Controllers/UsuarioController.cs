using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiPresupuestoApp.Api.Services.Interface;
using MiPresupuestoApp.Models.DTO;
using MiPresupuestoApp.Negocio.UOW.Interface;

namespace MiPresupuestoApp.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public readonly IUnitOfWork _unitOfWork;
        public readonly IUsuarioServicio _service;
        public readonly IMapper _mapper;

        public UsuarioController(IUnitOfWork unitOfWork, IUsuarioServicio service, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _service = service;
            _mapper = mapper;
        }


        [HttpPost("Register")]
        public ActionResult Register([FromForm]UserRegisterDto userRegisterDto)
        {
            try
            {
                var usuario = _service.Register(userRegisterDto, userRegisterDto.Password);
                return (usuario == null)
                    ? StatusCode(StatusCodes.Status201Created, usuario)
                    : StatusCode(StatusCodes.Status400BadRequest, "No se pudo registrar");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Login([FromForm]UserLoginDto userLoginDto)
        {
            try
            {
                var usuario = _service.Login(userLoginDto);
                return (usuario != null)
                    ? StatusCode(StatusCodes.Status202Accepted, _service.GetToken(usuario))
                    : StatusCode(StatusCodes.Status203NonAuthoritative, "Usuario y/o contraseña Incorreta");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }


        [HttpGet]
        public ActionResult Get(string correo)
        {
            try
            {
                var usuario = _unitOfWork.Usuario.GetByCondition(a => a.Correo.Equals(correo));
                return (usuario != null)
                    ? StatusCode(StatusCodes.Status200OK, _mapper.Map<UserDto>(usuario))
                    : StatusCode(StatusCodes.Status400BadRequest, "El usuario ingresado no se encuentra");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
