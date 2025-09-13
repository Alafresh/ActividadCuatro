using ActividadCuatro.Entidades;
using Microsoft.AspNetCore.Mvc;


namespace ActividadCuatro.Controllers {

    [Route("api")]
    public class UsuariosController{

        [HttpGet("usuarios/{username}")]
        public Usuario Get(string username) {
            DatosEnMemoria datos = new();
            Usuario usuario = datos.ObtenerPorUsername(username);
            return usuario;
        }
        [HttpGet("usuarios")]
        public List<Usuario> Get() {
            DatosEnMemoria datos = new();
            return datos.ObtenerTodosLosUsuarios();
        }
        [HttpPost("usuarios")]
        public void Post() {

        }
        [HttpPost("auth/login")]
        public void Login() {

        }
        [HttpPatch("usuarios")]
        public void Patch() {
            
        }
    }
}
