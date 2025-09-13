namespace ActividadCuatro.Entidades {
    public class Usuario {
        public string Username { get; set; }
        public string Password { get; set; }
        private string token;
        public bool state;
        public UserData data;

        public void SetToken(string token) {
            this.token = token;
        }
        public string GetToken() {
            return this.token;
        }
    }
    public class UserData {
        public int score;
    }
}
