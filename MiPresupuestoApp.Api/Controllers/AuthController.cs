using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MiPresupuestoApp.Api.Services.Interface;
using MiPresupuestoApp.Models.DTO;
using MiPresupuestoApp.Negocio.UOW.Interface;


namespace MiPresupuestoApp.Api.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        /// <summary>
        /// 
        /// </summary>
        public readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// 
        /// </summary>
        public readonly IUsuarioUtil _service;

        /// <summary>
        /// 
        /// </summary>
        public readonly IMapper _mapper;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="unitOfWork"></param>
        /// <param name="service"></param>
        /// <param name="mapper"></param>
        public AuthController(IUnitOfWork unitOfWork, IUsuarioUtil service, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _service = service;
            _mapper = mapper;
        }


        /// <summary>
        /// Registro de usuario
        /// </summary>
        /// <param name="userRegisterDto"></param>
        /// <returns>Datos del usuario (sin password)</returns>
        [HttpPost("Register")]
        public ActionResult Register([FromForm] UserRegisterDto userRegisterDto)
        {
            try
            {
                var usuario = _service.Register(userRegisterDto, userRegisterDto.Password);
                return (usuario != null)
                    ? StatusCode(StatusCodes.Status201Created, usuario)
                    : StatusCode(StatusCodes.Status400BadRequest, "No se pudo registrar");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Loguea el usuario
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns>TOKEN</returns>
        [HttpPost("login")]
        public ActionResult Login([FromForm] UserLoginDto userLoginDto)
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
    }
}
