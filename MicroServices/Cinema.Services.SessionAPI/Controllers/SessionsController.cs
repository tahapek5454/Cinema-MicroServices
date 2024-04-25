
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.SessionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetSessionById()
        {
            return null;
        }
    }
}
