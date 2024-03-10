using AutoMapper;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class UsuarioController : ControllerBase
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
        public UsuarioController(IUnitOfWork unitOfWork, IUsuarioUtil service, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _service = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Busca el usuario por CORREO
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        [HttpGet("correo")]
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

        /// <summary>
        /// Elimina el usuario buscando por Correo
        /// </summary>
        /// <param name="correo"></param>
        /// <returns></returns>
        [HttpDelete("{correo}")]
        public ActionResult Delete(string correo)
        {
            try
            {
                var usuario = _unitOfWork.Usuario.GetByCondition(a => a.Correo.Equals(correo));

                return (usuario != null)
                    ? (_unitOfWork.Usuario.Delete(usuario))
                        ? StatusCode(StatusCodes.Status200OK, "Se ha eliminado correctamente.")
                        : StatusCode(StatusCodes.Status400BadRequest, "No se ha podido eliminar el usuario")
                    : StatusCode(StatusCodes.Status400BadRequest, "No se encuentra el usuario");

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Modifica el usuario segun correo a buscar
        /// </summary>
        /// <param name="correo"></param>
        /// <param name="userDto"></param>
        /// <returns></returns>
        [HttpPut("correo")]
        public ActionResult Update([FromQuery(Name = "correo")]string correo, [FromBody]UserUpdateDto userDto)
        {
            try
            {
                var usuario = _unitOfWork.Usuario.GetByCondition(a => a.Correo.Equals(correo));

                if (usuario != null)
                {
                    usuario.Nombre = userDto.Nombre;
                    usuario.Apellido = userDto.Apellido;
                    usuario.Correo = userDto.Correo;
                    
                    return (_unitOfWork.Usuario.Update(usuario))
                        ? StatusCode(StatusCodes.Status200OK, _mapper.Map<UserDto>(usuario))
                        : StatusCode(StatusCodes.Status400BadRequest, "No se pudo modificar");
                }
                else 
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "No se encontro el correo ingresado.");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }



    }
}
