namespace Cinema.Services.AuthAPI.Application.Commands.RefreshToken
{
    public class RefreshTokenResponse
    {
        public string AccessToken { get; set; }
        public string UserName { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpire { get; set; }
    }
}
