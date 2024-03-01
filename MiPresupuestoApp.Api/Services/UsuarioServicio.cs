using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using MiPresupuestoApp.Api.Services.Interface;
using MiPresupuestoApp.Models;
using MiPresupuestoApp.Models.DTO;
using MiPresupuestoApp.Negocio.UOW.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace MiPresupuestoApp.Api.Services
{
    public class UsuarioServicio : IUsuarioServicio
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public UsuarioServicio(IUnitOfWork uow, IMapper mapper, IConfiguration configuration)
        {
            this._uow = uow;
            _mapper = mapper;
            _configuration = configuration;
        }


        public string GetToken(UserDto userDto)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, userDto.Id.ToString()),
                new Claim(ClaimTypes.Name, $"{userDto.Nombre}-{userDto.Apellido}"),
                new Claim(ClaimTypes.Email, userDto.Correo)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Expires = DateTime.UtcNow.AddMinutes(120),
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = credentials
            };
            //var claimsIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }


        private bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            var hMac = new HMACSHA512(passwordSalt);
            var hash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));

            for (var i = 0; i < hash.Length; i++)
            {
                if (hash[i] != passwordHash[i])
                {
                    return false;
                }
            }
            return true;
        }


        private void CrearPassHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            var hMac = new HMACSHA512();
            passwordSalt = hMac.Key;
            passwordHash = hMac.ComputeHash(Encoding.UTF8.GetBytes(password));
        }


        public UserDto Login(UserLoginDto userLoginDto)
        {
            var usuario = _uow.Usuario.GetByCondition(a => a.Correo.Equals(userLoginDto.Correo));
            if (usuario != null)
            {
                return (!VerifyPassword(userLoginDto.Password, usuario.PasswordHash, usuario.PasswordSalt))
                    ? null!
                    : _mapper.Map<UserDto>(usuario);
            }
            return null!;
        }

        public UserDto Register(UserRegisterDto userRegisterDto, string password)
        {
            byte[] passwordHash;
            byte[] passwordSalt;

            CrearPassHash(password, out passwordHash, out passwordSalt);
            var user = _mapper.Map<Usuario>(userRegisterDto);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _uow.Usuario.Insert(user);

            return _mapper.Map<UserDto>(user);
        }
    }
}
