using MediatR;

namespace Cinema.Services.AuthAPI.Application.Commands.RefreshToken
{
    public class RefreshTokenRequest: IRequest<RefreshTokenResponse>    
    {
        public string? RefreshToken { get; set; }
    }
}
