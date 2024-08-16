using Cinema.Services.RezervationAPI.Application.Dtos;
using Cinema.Services.RezervationAPI.Application.Mapper;
using Cinema.Services.RezervationAPI.Application.Request;
using Cinema.Services.RezervationAPI.Application.Services.Abstract;
using Cinema.Services.RezervationAPI.Domain.Entities;
using MassTransit;
using MassTransit.Transports;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Events.ReservationEvents;
using SharedLibrary.Models.Dtos;
using SharedLibrary.Settings;

namespace Cinema.Services.RezervationAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _rezervationService;
        private readonly ISendEndpointProvider _sendEndpointProvider;

        public ReservationsController(IReservationService rezervationService, ISendEndpointProvider sendEndpointProvider)
        {
            _rezervationService = rezervationService;
            _sendEndpointProvider = sendEndpointProvider;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRezervationById([FromRoute] int id)
        {
            var rezervation = await _rezervationService.Table.FirstOrDefaultAsync(x => x.Id == id);

            if (rezervation is null)
                throw new Exception("Rezervasyon bulunamadı");

            var rezervationDto = ObjectMapper.Mapper.Map<ReservationDto>(rezervation);

            return Ok(ResponseDto<ReservationDto>.Sucess(rezervationDto, 200));
        }



        [HttpPost]
        public async Task<IActionResult> CreateRezervation([FromBody] ReservationRequest request)
        {
            var reservation = ObjectMapper.Mapper.Map<Reservation>(request);

            await _rezervationService.Table.AddAsync(reservation);

            await _rezervationService.SaveChangesAsync();


            var sendEndpoint =
               await _sendEndpointProvider.GetSendEndpoint
               (new Uri($"queue:{RabbitMQSettings.ReservationStateMachineQueue}"));


            ReservedStartedEvent @event = new()
            {
                MovieTheaterId = request.MovieTheaterId,
                Price = request.Price,
                ReservationCreatedDate = DateTime.Now,
                ReservationId = reservation.Id,
                SeatIds = reservation.SeatIds,
                SessionId = request.SessionId,
                UserId = request.UserId,
            };

            await sendEndpoint.Send(@event);

            return Created("api/Rezervations/" + reservation.Id, ResponseDto<BlankDto>.Sucess(200));
        }



    }
}
