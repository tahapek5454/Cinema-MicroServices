using Cinema.Services.BranchAPI.Application.Commands.Branches.AddBranch;
using Cinema.Services.BranchAPI.Application.Queries.Branches.GetAllBranches;
using Cinema.Services.BranchAPI.Application.Queries.Branches.GetBrancheById;
using Cinema.Services.BranchAPI.Application.Queries.Branches.GetBranches;
using Cinema.Services.BranchAPI.Application.Queries.Branches.GetBranchesByDistrinct;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.BranchAPI.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BranchsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranches([FromQuery] GetAllBranchesRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> GetBranches([FromQuery] GetBranchesRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetBrancheById([FromRoute] GetBrancheByIdRequest request)
        {
            var r = await _mediator.Send(request);    

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> GetBranchesByDistrinct([FromQuery] GetBranchesByDistrinctRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody] AddBranchRequest request)
        {
            _ = await _mediator.Send(request);

            return Created();
        }

        // sonra guncelleme ve silme eklenir 
        // not: dinamik guncelleme
    }
}
