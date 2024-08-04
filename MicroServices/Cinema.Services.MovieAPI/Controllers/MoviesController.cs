using Cinema.Services.MovieAPI.Application.Commands.AddMovie;
using Cinema.Services.MovieAPI.Application.Commands.RemoveMovie;
using Cinema.Services.MovieAPI.Application.Commands.UpdateMovie;
using Cinema.Services.MovieAPI.Application.Queries.GetAllMovies;
using Cinema.Services.MovieAPI.Application.Queries.GetMovieById;
using Cinema.Services.MovieAPI.Application.Queries.GetMoviesWithPagination;
using Cinema.Services.MovieAPI.Services.Abstract;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.MovieAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController(IMediator _mediator, IMovieService _movieService) : ControllerBase
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovieById([FromRoute] GetMovieByIdRequest request)
        {
            var r = await _mediator.Send(request);
            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesWithPagination([FromQuery] GetMoviesWithPaginationRequest request)
        {
            var r = await _mediator.Send(request);
            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies([FromQuery] GetAllMoviesRequest request)
        {
            var r = await _mediator.Send(request);
            return Ok(r);
        }

        [HttpPost, Authorize(Roles = "admin")]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieRequest request)
        {
            var r = await _mediator.Send(request);

            return Created($"GetMovieById/{r.Result}", r);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody]  UpdateMovieRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveMovie([FromRoute] RemoveMovieRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }
    }
}
