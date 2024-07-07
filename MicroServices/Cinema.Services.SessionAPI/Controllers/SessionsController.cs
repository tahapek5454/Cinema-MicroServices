
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
        public async Task<IActionResult> GetSessionsByMovieId([FromRoute] int id)
        {
            var session = await _sessionService.Table.Where(x => x.MovieId == id).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<SessionDto>>(session);

            return Ok(ResponseDto<List<SessionDto>>.Sucess(result, 200));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatWithStatusBySessionId([FromRoute] int id)
        {
            List<SeatSessionStatusDto> response = new();

            var movieTheaterId = await _sessionService.Table
                .Where(s => s.Id == id)
                .Select(x => x.MovieTheaterId)
                .FirstOrDefaultAsync();

            var seatSessionStatus = await _seatStatusService
                .Table
                .Include(s => s.Seat)
                .Include(s => s.Session)
                .Where(x => x.SessionId == id)
                .ToListAsync();


            response = ObjectMapper.Mapper.Map<List<SeatSessionStatusDto>>(seatSessionStatus);

            
            var seats = await _seatService
                .Table
                .Where(x => x.MovieTheaterId == movieTheaterId)
                .ToListAsync();

            foreach (var item in seats)
            {
                if(!response.Exists(x => x.SeatId == item.Id))
                {
                    response.Add(new SeatSessionStatusDto()
                    {
                        Id = -1,
                        Reserved = false,
                        SeatId = item.Id,
                        SeatNumber = item.SeatNumber,
                        SessionId = id,
                    });
                }
            }

            response = response.OrderBy(x => x.SeatNumber).ToList();

            return Ok(ResponseDto<List<SeatSessionStatusDto>>.Sucess(response, 200));

        }


    }
}
