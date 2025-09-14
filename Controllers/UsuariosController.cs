using ActividadCuatro.Entidades;
using Microsoft.AspNetCore.Mvc;


namespace ActividadCuatro.Controllers {

    [Route("api")]
    public class UsuariosController : ControllerBase {

        private readonly DatosEnMemoria datos = new();

        [HttpGet("usuarios/{username}")]
        public ActionResult<Usuario> Get(string username) {

            Usuario? usuario = datos.ObtenerPorUsername(username);

            if (usuario is null)
                return NotFound();

            return usuario;
        }
        [HttpGet("usuarios")]
        public List<Usuario> Get() {
            return datos.ObtenerTodosLosUsuarios();
        }
        [HttpPost("usuarios")]
        public ActionResult<Usuario> Registro([FromBody] Usuario usuario) {
            
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

            AuthResponse authResponse = new AuthResponse(usuarioDB);

            return authResponse;
        }
        [HttpPatch("usuarios")]
        public void Patch() {
            
        }
    }
}
