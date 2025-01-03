﻿using Cinema.Services.SessionAPI.Application.Dtos;
using Cinema.Services.SessionAPI.Application.Mapper;
using Cinema.Services.SessionAPI.Application.Request;
using Cinema.Services.SessionAPI.Application.Services.Abstract;
using Cinema.Services.SessionAPI.Application.Services.Abstract.HubServices;
using Cinema.Services.SessionAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Enums;
using SharedLibrary.Helpers;
using SharedLibrary.Models.Dtos;



namespace Cinema.Services.SessionAPI.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SessionsController(
            ISessionService _sessionService,
            ISeatService _seatService,
            ISeatSessionStatusService _seatStatusService,
            ISeatStatusHubService _seatStatusHubService
        ) : ControllerBase
    {

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSessionById([FromRoute] int id)
        {
            var session = await _sessionService.Table.Include(x => x.MovieTheater).AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);

            var result = ObjectMapper.Mapper.Map<SessionDto>(session);

            return Ok(ResponseDto<SessionDto>.Sucess(result, 200).Data);
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

        [HttpGet]
        public async Task<IActionResult> GetAllSessionsByBranchAndMovieId([FromQuery] int branchId, [FromQuery] int movieId)
        {
            var session = await _sessionService
                .Table
                .AsNoTracking()
                .Include(x => x.MovieTheater)
                .Where(x => x.MovieTheater.BranchId == branchId && x.MovieId == movieId)
                .ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<SessionDto>>(session);

            return Ok(ResponseDto<List<SessionDto>>.Sucess(result, 200).Data);
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
                .Include(x => x.Seat)
                .ToListAsync();

            response = ObjectMapper.Mapper.Map<List<SeatSessionStatusDto>>(seatSessionStatus);


            var seats = await _seatService
                .Table
                .Where(x => x.MovieTheaterId == movieTheaterId)
                .ToListAsync();

            foreach (var item in seats)
            {
                if (!response.Exists(x => x.SeatId == item.Id))
                {
                    response.Add(new SeatSessionStatusDto()
                    {
                        ReservedStatus = ReservedStatusEnum.NotReserved,
                        SeatId = item.Id,
                        SeatNumber = item.SeatNumber,
                        SessionId = id,
                    });
                }
            }

            response = response.OrderBy(x => x.SeatNumber).ToList();

            return Ok(ResponseDto<List<SeatSessionStatusDto>>.Sucess(response, 200).Data);

        }

        [HttpPost]
        public async Task<IActionResult> GetSeatsByIds([FromBody] GetSeatsByIdsRequest request)
        {
            var e = _seatService.Table.Where(x => request.SeatIds.Contains(x.Id)).ToList();

            var r = ObjectMapper.Mapper.Map<List<SeatDto>>(e);

            return Ok(r);
        }


        [HttpGet]
        public async Task<IActionResult> GetSeatsBySessionIdAndUserId([FromQuery] int userId, [FromQuery] int sessionId)
        {
            var r = _seatStatusService.Table.AsNoTracking()
                .Include(x => x.Seat)
                .Where(x => x.UserId.Equals(userId) && x.SessionId.Equals(sessionId) && x.ReservedStatus == ReservedStatusEnum.Pending)
                .ToList();

            var seeatEnttiy = r.Select(x => x.Seat);

            if (seeatEnttiy.Any())
            {
                var seats = ObjectMapper.Mapper.Map<List<SeatDto>>(seeatEnttiy);

                return Ok(seats);
            }

            return Ok(new List<SeatDto>());
        }


        [HttpPost]
        public async Task<IActionResult> PreBookingOrCancel([FromBody] PreBookingRequest request)
        {
            

            switch (request.ReservedStatus)
            {
                case ReservedStatusEnum.NotReserved: // iptal etmek istiyor. Sadece pre booking eden kullanıcı iptal edebilir.
                    {
                        var seatSessionStatus = _seatStatusService.Table
                                                                    .AsNoTracking()
                                                                    .Where(x => x.SessionId.Equals(request.SessionId) && x.SeatId.Equals(request.SeatId))
                                                                    .FirstOrDefault();

                        if (seatSessionStatus == null) // olmayan bir seyi iptal etmeye calisiyorsun gerek yok yazma amacim kontrol
                            return Ok();


                        if (seatSessionStatus.UserId == null) // hali hazirda iptal edilmis bir seyi iptal etmeye calisiyor ok de gec
                            return Ok();


                        if (seatSessionStatus.UserId != request.UserId) // baskasinin islemine dokunamazsin
                            throw new Exception("Başkası tarafından rezerv edilmiş bir yer ile ilgili işlem yapamazsınız.");




                        // iptal edebilirsin, iptal isleminde sonra digerlerinin koltugu rezerve edebilmesi adina userId ye null ata sahipsiz yap yani
                        seatSessionStatus.ReservedStatus = request.ReservedStatus;
                        seatSessionStatus.UserId = null;

                        _seatStatusService.Update(seatSessionStatus);
                        await _seatStatusService.SaveChangesAsync();


                        var seatSessionDto = ObjectMapper.Mapper.Map<SeatSessionStatusDto>(seatSessionStatus);
                        await _seatStatusHubService.SendMessageToGroupAsync(request.SessionId, seatSessionDto);

                        return Ok();

                    }
       
                case ReservedStatusEnum.Pending:
                    {
                        var seatSessionStatus = _seatStatusService.Table
                                                                    .AsNoTracking()         
                                                                    .Where(x => x.SessionId.Equals(request.SessionId) && x.SeatId.Equals(request.SeatId))
                                                                    .FirstOrDefault();

                        if(seatSessionStatus == null) // ilk defa pre rezerve edileccek kaydedebilirsib
                        {
                            seatSessionStatus = ObjectMapper.Mapper.Map<SeatSessionStatus>(request);
                            await _seatStatusService.Table.AddAsync(seatSessionStatus);
                            await _seatStatusService.SaveChangesAsync();

                            var seatSessionDto = ObjectMapper.Mapper.Map<SeatSessionStatusDto>(seatSessionStatus);
                            await _seatStatusHubService.SendMessageToGroupAsync(request.SessionId, seatSessionDto);

                            return Ok();
                        }

                        if(seatSessionStatus.UserId == null) // onceki user tarafindan iptal edilmis o zaman alinabilir
                        {
                            seatSessionStatus.UserId = request.UserId;
                            seatSessionStatus.ReservedStatus = request.ReservedStatus;
                            _seatStatusService.Update(seatSessionStatus);
                            await _seatStatusService.SaveChangesAsync();

                            var seatSessionDto = ObjectMapper.Mapper.Map<SeatSessionStatusDto>(seatSessionStatus);
                            await _seatStatusHubService.SendMessageToGroupAsync(request.SessionId, seatSessionDto);

                            return Ok();
                        }

                        if(seatSessionStatus.UserId != request.UserId)  // baskasinin islemine dokunamazsin
                            throw new Exception("Başkası tarafından rezerv edilmiş bir yer ile ilgili işlem yapamazsınız.");



                        break; // ayni user pre booking ettigi yeri tekrar etmeye calisti breakle gec

                    }
      
                case ReservedStatusEnum.Reserved:
                    throw new Exception("Ön aşamada rezerv edilemez.");
                default:
                    break;
            }

            return Ok();

        }



    }
}
