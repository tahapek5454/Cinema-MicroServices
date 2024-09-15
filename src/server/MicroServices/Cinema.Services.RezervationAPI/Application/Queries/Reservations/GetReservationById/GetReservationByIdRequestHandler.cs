using Cinema.Services.RezervationAPI.Application.Dtos;
using Cinema.Services.RezervationAPI.Application.Mapper;
using Cinema.Services.RezervationAPI.Application.Services.Abstract;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Services.RezervationAPI.Application.Queries.Reservations.GetReservationById
{
    public class GetReservationByIdRequestHandler(IReservationService _reservationService) : IRequestHandler<GetReservationByIdRequest, GetReservationByIdResponse>
    {
        public async Task<GetReservationByIdResponse> Handle(GetReservationByIdRequest request, CancellationToken cancellationToken)
        {
            var rezervation = await _reservationService.Table.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (rezervation is null)
                throw new Exception("Rezervasyon bulunamadı");

            var rezervationDto = ObjectMapper.Mapper.Map<ReservationDto>(rezervation);

            return new()
            {
                CreatedDate = rezervationDto.CreatedDate,
                Id = rezervationDto.Id,
                IsPaymentRealised = rezervationDto.IsPaymentRealised,
                MovieTheaterId = rezervationDto.MovieTheaterId,
                Price = rezervationDto.Price,
                SeatIds = rezervationDto.SeatIds,
                SessionId = rezervationDto.SessionId,
                UserId = rezervationDto.UserId,
            };
        }
    }
}
