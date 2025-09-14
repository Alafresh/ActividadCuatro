using ActividadCuatro.Entidades;
using Microsoft.AspNetCore.Mvc;


namespace ActividadCuatro.Controllers {

    [Route("api")]
    public class UsuariosController : ControllerBase {

        private readonly DatosEnMemoria datos = new();

        [HttpPost("usuarios")]
        public ActionResult<AuthData> Registro([FromBody] AuthData usuario) {

            if (string.IsNullOrEmpty(usuario.Username))
                return BadRequest("Error en usuario ");

            if (string.IsNullOrEmpty(usuario.Password))
                return BadRequest("Error en contraseña");

            bool existeUsuario = datos.Existe(usuario.Username);

            if (existeUsuario)
                return BadRequest($"Ya existe el usuario {usuario.Username}");

            datos.Crear(usuario);
            return usuario;
        }

        [HttpPost("auth/login")]
        public ActionResult<AuthResponse> Login([FromBody] AuthData usuario) {

            if (string.IsNullOrEmpty(usuario.Username))
                return BadRequest("debe enviar el campo username en la petición");

            if (string.IsNullOrEmpty(usuario.Password))
                return BadRequest("debe enviar el campo password en la petición");

            Usuario? usuarioDB = datos.ObtenerPorUsername(usuario.Username);

            if (usuarioDB is null)
                return NotFound($"No existe el usuario {usuario.Username}");

            if (usuarioDB.Password != usuario.Password)
                return BadRequest("Contraseña incorrecta");

            string token = datos.GenerarToken();
            usuarioDB.Token = token;

            AuthResponse authResponse = new(usuarioDB);

            return authResponse;
        }

        [HttpGet("usuarios/{username}")]
        public ActionResult<Usuario> Get([FromHeader(Name = "x-token")] string token, string username) {

            if (string.IsNullOrEmpty(token))
                return BadRequest("debe enviar el campo token en la peticion");

            Usuario? usuario = datos.ObtenerPorUsername(username);

            if (usuario is null)
                return NotFound("Usuario no encontrado");

            if (usuario.Token == token)
                return usuario;

            return NotFound();
        }

        [HttpPatch("usuarios")]
        public ActionResult<Usuario> Patch([FromHeader(Name = "x-token")] string token, [FromBody] User usuario) {
            
            if (string.IsNullOrEmpty(token))
                return BadRequest("debe enviar el campo token en la peticion");

            Usuario? usuarioDb = datos.ObtenerPorUsername(usuario.Username);

            if (usuarioDb is null)
                return NotFound("Usuario no encontrado");

            usuarioDb.Data.Score = usuario.Data.Score;

            return usuarioDb;
        }

        [HttpGet("usuarios")]
        public ActionResult<List<Usuario>> Get([FromHeader(Name = "x-token")] string token) {
            
            if (string.IsNullOrEmpty(token))
                return NotFound("debe enviar el campo token en la peticion");

            return datos.TokenValido(token) ? datos.ObtenerTodosLosUsuarios() : NotFound("Token invalido");
        }
    }
}
