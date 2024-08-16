using Cinema.Services.FileAPI.Application.Dtos;
using Cinema.Services.FileAPI.Application.Services.Abstract;
using Cinema.Services.FileAPI.Domain.Entities;
using Cinema.Services.FileAPI.Storages.Abstract;
using MassTransit;
using MassTransit.Initializers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Events.MovieImageEvents;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Settings;


namespace Cinema.Services.FileAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieImagesController(IMovieImageService _movieImageService, IStorageService _storageService, ISendEndpointProvider _sendEndpointProvider) : ControllerBase
    {
        [HttpPost, Authorize(Roles = "admin")]
        public async Task<IActionResult> UploadImageFile([FromQuery] UploadImageFileRequestDto uploadImageFileRequestDto)
        {
            var formFileCollection = Request.Form.Files;

            if (formFileCollection == null)
                return BadRequest(ResponseDto<BlankDto>.Fail("Couldn't Access Files", true, 500));

            var result = await _storageService.UploadAsync("images", formFileCollection);

            List<MovieImage> images = new List<MovieImage>();

            result.ForEach(item =>
            {
                MovieImage image = new MovieImage()
                {
                    FileName = item.fileName,
                    Path = item.pathOrContainerName,
                    Storage = _storageService.StorageName,
                    RelationId = uploadImageFileRequestDto.RelationId
                };

                images.Add(image);
            });

            if (!images.Any())
            {
                foreach (var item in result)
                    await _storageService.DeleteAsync("images", item.fileName);

                return BadRequest(ResponseDto<BlankDto>.Fail("Couldn't Save Files", true, 500));
            }

            await _movieImageService.Table.AddRangeAsync(images);
            await _movieImageService.SaveChangesAsync();

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.FileStateMachineQueue}"));

            images.ForEach(async image =>
            {
                MovieImageUploadStartedEvent movieImageUploadStartedEvent = new MovieImageUploadStartedEvent()
                {
                    FileId = image.Id,
                    FileName = image.FileName,
                    Path = image.Path,
                    RelationId = image.RelationId,
                    Storage = image.Storage,

                };

                await sendEndpoint.Send(movieImageUploadStartedEvent);
            });

            return Ok(ResponseDto<BlankDto>.Sucess(201));
        }

        [HttpDelete, Authorize(Roles = "admin")]
        public async Task<IActionResult> DeleteImageFile(string fileName)
        {
            await _storageService.DeleteAsync("images", fileName);

            var file = await _movieImageService.Table.FirstOrDefaultAsync(x => x.FileName.Equals(fileName));

            MovieImageDeleteStartedEvent movieImageDeleteStartedEvent = new MovieImageDeleteStartedEvent()
            {
                FileId = file.Id,
                FileName = file.FileName,
                Path = file.Path,
                RelationId = file.RelationId,
                Storage = file.Storage,

            };

            if (file is null)
                throw new Exception("File Not Found");

            _movieImageService.Table.Remove(file);
            await _movieImageService.SaveChangesAsync();

            var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(new Uri($"queue:{RabbitMQSettings.FileStateMachineQueue}"));

            await sendEndpoint.Send(movieImageDeleteStartedEvent);

            return Ok(ResponseDto<BlankDto>.Sucess(201));

        }
    }
}
