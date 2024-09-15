using MediatR;

namespace Cinema.Services.RezervationAPI.Application.Commands.Reservations.CreateReservation
{
    public class CreateReservationRequest: IRequest<CreateReservationResponse>
    {
        public int SessionId { get; set; }
        public int UserId { get; set; }
        public List<int> SeatIds { get; set; }
        public int MovieTheaterId { get; set; }
        public int Price { get; set; }
    }
}
