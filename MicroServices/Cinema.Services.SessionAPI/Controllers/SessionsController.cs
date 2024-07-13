
using Cinema.Services.SessionAPI.Mapper;
using Cinema.Services.SessionAPI.Models.Dtos;
using Cinema.Services.SessionAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Enums;
using SharedLibrary.Helpers;
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
            var session = await _sessionService.Table.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            var result = ObjectMapper.Mapper.Map<SessionDto>(session);

            return Ok(ResponseDto<SessionDto>.Sucess(result, 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionsByMovieId([FromRoute] int id)
        {
            var session = await _sessionService.Table.AsNoTracking().Where(x => x.MovieId == id).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<SessionDto>>(session);

            return Ok(ResponseDto<List<SessionDto>>.Sucess(result, 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSessionByMovieTheater([FromRoute] int id)
        {
            var session = await _sessionService.Table.AsNoTracking().Where(x => x.MovieTheaterId == id).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<SessionDto>>(session);

            return Ok(ResponseDto<List<SessionDto>>.Sucess(result, 200));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetAllSessionByMovieTheaterByDate([FromRoute] int id, [FromBody] DateTime dateTime)
        {
            // this date for week

            var (startOfWeek, endOfWeek) = CalculateMethods.FindWeekArrange(dateTime);

            var session = await _sessionService.Table
                .AsNoTracking()
                .Where(x => x.MovieTheaterId == id && x.CreatedDate >= startOfWeek && x.CreatedDate <= endOfWeek).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<SessionDto>>(session);

            return Ok(ResponseDto<List<SessionDto>>.Sucess(result, 200));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetSeatWithStatusBySessionId([FromRoute] int id)
        {
            List<SeatSessionStatusDto> response = new();

            var movieTheaterId = await _sessionService.Table
                .AsNoTracking()
                .Where(s => s.Id == id)
                .Select(x => x.MovieTheaterId)
                .FirstOrDefaultAsync();

            var seatSessionStatus = await _seatStatusService
                .Table
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
                        ReservedStatus = ReservedStatusEnum.NotReserved,
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
