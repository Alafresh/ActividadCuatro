using ActividadCuatro.Entidades;
using Microsoft.AspNetCore.WebUtilities;
using System.Security.Cryptography;

namespace ActividadCuatro {
    public class DatosEnMemoria {

        private static List<Usuario> _misUsuarios = new() {
            new Usuario { Username = "manolo", Password = "123456" },
            new Usuario { Username = "adolfo", Password = "123456" }
        };

        public DatosEnMemoria() {}
        public List<Usuario> ObtenerTodosLosUsuarios() => _misUsuarios;
        public Usuario? ObtenerPorUsername(string username) => _misUsuarios.FirstOrDefault(u => u.Username == username);
        public void Crear(Usuario usuario) => _misUsuarios.Add(usuario);
        public bool Existe(string username) => _misUsuarios.Any(u => u.Username == username);

        public string GenerarToken() {
            byte[] bytes = RandomNumberGenerator.GetBytes(32);
            return WebEncoders.Base64UrlEncode(bytes);
        }

    }
}
