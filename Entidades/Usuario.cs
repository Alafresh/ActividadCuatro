namespace ActividadCuatro.Entidades {
    public class Usuario {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get => token; set => token = value; }
        private string token;
        public bool state;
        public UserData data;
    }
    public class UserData {
        public int score;
    }

    public class AuthData {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class AuthResponse {
        public string Usuario { get; set; }
        public string Token { get; set; }

        public AuthResponse(Usuario usuarioBD) {
            Usuario = usuarioBD.Username;
            Token = usuarioBD.Token;
        }
    }
}
