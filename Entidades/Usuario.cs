namespace ActividadCuatro.Entidades {
    public class Usuario {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Token { get => token; set => token = value; }
        private string? token;
        public bool state;
        public UserData Data { get ; set; } = new ();
    }
    public class UserData {
        public int Score { get; set; }
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
    public class User {
        public string Username { get; set; }
        public UserData Data { get; set; }
    }
}
