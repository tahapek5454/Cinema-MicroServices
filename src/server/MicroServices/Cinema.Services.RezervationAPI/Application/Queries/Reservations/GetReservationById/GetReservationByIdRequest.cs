using MediatR;

namespace Cinema.Services.RezervationAPI.Application.Queries.Reservations.GetReservationById
{
    public class GetReservationByIdRequest: IRequest<GetReservationByIdResponse>
    {
        public int Id { get; set; }
    }
}
