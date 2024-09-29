using Cinema.Services.MovieAPI.Application.Commands.Movies.AddMovie;
using Cinema.Services.MovieAPI.Application.Commands.Movies.RemoveMovie;
using Cinema.Services.MovieAPI.Application.Commands.Movies.UpdateMovie;
using Cinema.Services.MovieAPI.Application.Queries.Movies.GetAllMovies;
using Cinema.Services.MovieAPI.Application.Queries.Movies.GetMovieById;
using Cinema.Services.MovieAPI.Application.Queries.Movies.GetMoviesWithPagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.MovieAPI.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MoviesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetMovieById([FromRoute] GetMovieByIdRequest request)
        {
            var r = await _mediator.Send(request);
            return Ok(r.Result);
        }

        [HttpGet]
        public async Task<IActionResult> GetMoviesWithPagination([FromQuery] GetMoviesWithPaginationRequest request)
        {
            var r = await _mediator.Send(request);
            return Ok(r.Result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMovies([FromQuery] GetAllMoviesRequest request)
        {
            var r = await _mediator.Send(request);
            return Ok(r.Result);
        }

        [HttpPost, Authorize(Roles = "admin")]
        public async Task<IActionResult> AddMovie([FromBody] AddMovieRequest request)
        {
            var r = await _mediator.Send(request);

            return Created($"GetMovieById/{r.Result}", r);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMovie([FromBody] UpdateMovieRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r.Result);
        }

        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveMovie([FromRoute] RemoveMovieRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r.Result);
        }
    }
}
