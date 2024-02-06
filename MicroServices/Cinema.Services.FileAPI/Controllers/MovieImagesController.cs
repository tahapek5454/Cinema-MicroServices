using Cinema.Services.FileAPI.Models;
using Cinema.Services.FileAPI.Models.Dtos;
using Cinema.Services.FileAPI.Services.Abstract;
using Cinema.Services.FileAPI.Storages.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.FileAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovieImagesController(IMovieImageService _movieImageService, IStorageService _storageService) : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadImageFile([FromQuery] UploadImageFileRequestDto uploadImageFileRequestDto)
        {
            var formFileCollection = Request.Form.Files;

            if (formFileCollection == null)
                return BadRequest(ResponseDto<BlankDto>.Fail("Couldn't Access Files",true ,500));

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

            return Ok(ResponseDto<BlankDto>.Sucess(201));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteImageFile(string fileName)
        {
            await _storageService.DeleteAsync("images", fileName);

            var file = await _movieImageService.Table.FirstOrDefaultAsync(x => x.FileName.Equals(fileName));
            if (file is null)
                throw new Exception("File Not Found");

            _movieImageService.Table.Remove(file);
            await _movieImageService.SaveChangesAsync();
            return Ok(ResponseDto<BlankDto>.Sucess(201));

        }
    }
}
