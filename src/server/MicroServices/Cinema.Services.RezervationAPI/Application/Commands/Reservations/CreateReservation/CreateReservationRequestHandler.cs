using Cinema.Services.RezervationAPI.Application.Mapper;
using Cinema.Services.RezervationAPI.Application.Services.Abstract;
using Cinema.Services.RezervationAPI.Domain.Entities;
using Cinema.Services.RezervationAPI.Infrastructure.Services.Concrete;
using MassTransit;
using MediatR;
using SharedLibrary.Events.ReservationEvents;
using SharedLibrary.Settings;

namespace Cinema.Services.RezervationAPI.Application.Commands.Reservations.CreateReservation
{
    public class CreateReservationRequestHandler(IReservationService _reservationService, ReservationUnitOfWork _reservationUnitOfWork, ISendEndpointProvider _sendEndpointProvider) : IRequestHandler<CreateReservationRequest, CreateReservationResponse>
    {
        public async Task<CreateReservationResponse> Handle(CreateReservationRequest request, CancellationToken cancellationToken)
        {
            var reservation = ObjectMapper.Mapper.Map<Reservation>(request);

            await _reservationService.Table.AddAsync(reservation);

            await _reservationUnitOfWork.SaveChangesAsync();


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

            return new();
        }
    }
}
