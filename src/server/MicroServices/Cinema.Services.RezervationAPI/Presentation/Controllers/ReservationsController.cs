using Cinema.Services.RezervationAPI.Application.Commands.Reservations.CreateReservation;
using Cinema.Services.RezervationAPI.Application.Queries.Reservations.GetReservationById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.RezervationAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetReservationById([FromRoute] GetReservationByIdRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }



        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] CreateReservationRequest request)
        {
            _ = await _mediator.Send(request);

            return Created();
        }



    }
}
