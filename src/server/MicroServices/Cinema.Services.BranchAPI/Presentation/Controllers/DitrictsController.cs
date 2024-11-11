using Cinema.Services.BranchAPI.Application.Commands.Districts.AddDistrict;
using Cinema.Services.BranchAPI.Application.Queries.Districts.GetAllDistricts;
using Cinema.Services.BranchAPI.Application.Queries.Districts.GetDistrictById;
using Cinema.Services.BranchAPI.Application.Queries.Districts.GetDistricts;
using Cinema.Services.BranchAPI.Application.Queries.Districts.GetDistrictsByCity;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.BranchAPI.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DitrictsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DitrictsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDistricts([FromQuery] GetAllDistrictsRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> GetDistricts([FromQuery] GetDistrictsRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetDistrictById([FromRoute] GetDistrictByIdRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> GetDistrictByCity([FromQuery] GetDistrictsByCityRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> AddDistrict([FromBody] AddDistrictRequest request)
        {
            var r = await _mediator.Send(request);

            return Created();
        }
    }
}
