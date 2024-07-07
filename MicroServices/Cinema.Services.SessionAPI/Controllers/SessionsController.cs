
using Cinema.Services.SessionAPI.Mapper;
using Cinema.Services.SessionAPI.Models.Dtos;
using Cinema.Services.SessionAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;


namespace Cinema.Services.SessionAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SessionsController(
            ISessionService _sessionService,
            ISeatService _seatService,
            ISeatSessionStatusService _seatStatusService
        ) : ControllerBase
    {
                
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById([FromRoute] int id)
        {
            var session = await _sessionService.Table.FirstOrDefaultAsync(x => x.Id == id);

            var result = ObjectMapper.Mapper.Map<SessionDto>(session);

            return Ok(ResponseDto<SessionDto>.Sucess(result, 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionByMovie([FromRoute] int id)
        {
            var session = await _sessionService.Table.FirstOrDefaultAsync(x => x.MovieId == id);

            var result = ObjectMapper.Mapper.Map<SessionDto>(session);

            return Ok(ResponseDto<SessionDto>.Sucess(result, 200));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatWithStatusBySession([FromRoute] int id)
        {
            List<SessionSeatDto> response = new();

            var session = await _sessionService.Table.FirstOrDefaultAsync(x => x.Id == id);

            var seatStatus = await _seatStatusService.Table.Where(x => x.SessionId.Equals(id))
                .ToListAsync();

            var allSeat = await _seatService.Table.Where(x => x.MovieTheaterId.Equals(session.MovieTheaterId))
                    .ToListAsync();

            if (!seatStatus.Any())
            {
                response.AddRange(
                        allSeat.Select(x => new SessionSeatDto()
                        {          
                            Reserved = false,
                            SeatId = x.Id,
                            MovieTheaterId = x.MovieTheaterId,
                            SeatNumber = x.SeatNumber,
                            SessionId = id
                    
                        })
                    );

                return Ok(ResponseDto<List<SessionSeatDto>>.Sucess(response, 200));
            }

            var reservedSeatIds = seatStatus.Select(x =>
            {
                if (x.Reserved)
                    return x.SeatId;

                return -1;
            }).ToList();

            reservedSeatIds.RemoveAll(x => x.Equals(-1));

            response.AddRange(

                    allSeat.Select(x =>
                    {
                        if (reservedSeatIds.Contains(x.Id))
                        {
                            return new SessionSeatDto()
                            {
                                Reserved = true,
                                SeatId = x.Id,
                                MovieTheaterId = x.MovieTheaterId,
                                SeatNumber = x.SeatNumber,
                                SessionId = id
                            };
                        }

                        return new SessionSeatDto()
                        {
                            Reserved = false,
                            SeatId = x.Id,
                            MovieTheaterId = x.MovieTheaterId,
                            SeatNumber = x.SeatNumber,
                            SessionId = id
                        };

                    })
               
                );

            return Ok(ResponseDto<List<SessionSeatDto>>.Sucess(response, 200));

        }


    }
}
