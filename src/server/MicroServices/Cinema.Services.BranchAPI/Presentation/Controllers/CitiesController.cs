using Cinema.Services.BranchAPI.Application.Commands.Cities.AddCity;
using Cinema.Services.BranchAPI.Application.Queries.Cities.GetAllCities;
using Cinema.Services.BranchAPI.Application.Queries.Cities.GetCities;
using Cinema.Services.BranchAPI.Application.Queries.Cities.GetCityById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.BranchAPI.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities([FromQuery] GetAllCitiesRequest request) 
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> GetCities([FromQuery] GetCitiesRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCityById([FromRoute] GetCityByIdRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] AddCityRequest request)
        {
            _ = await _mediator.Send(request);

            return Created();
        }
    }
}
