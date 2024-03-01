using AutoMapper;
using Microsoft.AspNetCore.Http;
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


        [HttpPost]
        public ActionResult Register([FromForm]UserRegisterDto userRegisterDto)
        {
            try
            {
                var usuario = _service.Register(userRegisterDto, userRegisterDto.Password);
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

    }
}
