using Cinema.Services.FileAPI.Application.Commands.MovieImages.DeleteImageFile;
using Cinema.Services.FileAPI.Application.Commands.MovieImages.UploadImageFile;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Cinema.Services.FileAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieImagesController(IMediator _mediator) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImageFile([FromQuery] UploadImageFileRequest request)
        {
            request.FormFileCollection = Request.Form.Files;

            _ = await _mediator.Send(request);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImageFile([FromBody] DeleteImageFileRequest request)
        {
            _ = await _mediator.Send(request);

            return Ok();

        }
    }
}
