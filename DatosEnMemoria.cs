using ActividadCuatro.Entidades;

namespace ActividadCuatro {
    public class DatosEnMemoria {

        private List<Usuario> _misUsuarios;

        public DatosEnMemoria() {
            _misUsuarios =
            [
                new Usuario { Username = "manolo", Password = "123456" },
                new Usuario { Username = "adolfo", Password = "123456" }
            ];
        }
        public List<Usuario> ObtenerTodosLosUsuarios() => _misUsuarios;
        public Usuario? ObtenerPorUsername(string username) => _misUsuarios.FirstOrDefault(u => u.Username == username);
        
    }
}
