namespace Cinema.Services.AuthAPI.Application.Commands.Login
{
    public class LoginResponse
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpire { get; set; }
    }
}
