using Cinema.Services.AuthAPI.Application.Commands.Login;
using Cinema.Services.AuthAPI.Application.Commands.RefreshToken;
using Cinema.Services.AuthAPI.Application.Commands.Register;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.AuthAPI.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            var r = await _mediator.Send(loginRequest);

            return Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequest registerRequest)
        {
            _ = await _mediator.Send(registerRequest);

            return Created();
        }


        [HttpPost]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }
    }
}
