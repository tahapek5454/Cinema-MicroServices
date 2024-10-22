using Cinema.Services.AiAssistant.Services.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.AiAssistant.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AiController(IAiService _aiService) : ControllerBase
    {
        [HttpGet]
        public IActionResult HealthCheck()
        {
            var r = _aiService.HealthCheck();

            return Ok(r);
        }

        [HttpGet]
        public IActionResult FunctionCallTest([FromQuery] string content)
        {
            var r = _aiService.FunctionCallTest(content);

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> AssistanTest([FromQuery] string content)
        {
            var r = await _aiService.AssistantTest(content);

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> MovieAssistantTest([FromQuery] string content, [FromQuery] string? threadId)
        {
            var r = await _aiService.MovieAssistant(content, threadId);

            return Ok(r);
        }


        [HttpGet]
        public async Task<IActionResult> CreateAssistant()
        {
            var r = await _aiService.CreateAssistant();

            return Ok(r);
        }
    }
}
