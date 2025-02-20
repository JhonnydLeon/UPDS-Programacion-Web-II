using APICliente.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using APICliente.Modelos.Dto;
using APICliente.Modelos;

namespace APICliente.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepositorio _userRepositorio;
        protected ReponseDto _response;

        public UsersController(IUserRepositorio userRepositorio)
        {
            _userRepositorio = userRepositorio;
            _response = new ReponseDto();
        }
        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDto user)
        {
            var respuesta = await _userRepositorio.Register(
                new User { UserName = user.UserName }, user.Password);

            if (respuesta == "existe")
            {
                return BadRequest(new
                {
                    isSuccess = false,
                    result = (object)null,
                    displayMessage = "El nombre de usuario ya existe.",
                    errorMessages = new[] { "El nombre de usuario ya está registrado." }
                });
            }

            if (respuesta == "error")
            {
                return BadRequest(new
                {
                    isSuccess = false,
                    result = (object)null,
                    displayMessage = "Error al crear el usuario.",
                    errorMessages = new[] { "Ocurrió un error inesperado." }
                });
            }

            // Si el registro es exitoso, devolver una respuesta con los datos del usuario
            return Ok(new
            {
                isSuccess = true,
                result = new
                {
                    userName = user.UserName,
                    token = respuesta // Asegúrate de que "respuesta" sea el token JWT
                },
                displayMessage = "Usuario creado con éxito.",
                errorMessages = (string[])null
            });
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDto user)
        {
            var respuesta = await _userRepositorio.login(user.UserName, user.Password);
            if (respuesta == "no user")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "Usuario no Existe";
                return BadRequest(_response);

            }

            if (respuesta == "wrongpassword")
            {
                _response.IsSuccess = false;
                _response.DisplayMessage = "password incorrecto";
                return BadRequest(_response);
            }

            //lo  que estamos agregando es por autorizacion de JwTokens

            _response.Result = respuesta;
            JwTPackge jwt = new JwTPackge();

            jwt.UserName = user.UserName;
            jwt.Token = respuesta;
            _response.Result = jwt;

            _response.DisplayMessage = "usuario conectado";

            return Ok(_response);

        }











    }


    public class JwTPackge
    {
        public string? UserName { get; set; }
        public string? Token { get; set; }
    }





}
