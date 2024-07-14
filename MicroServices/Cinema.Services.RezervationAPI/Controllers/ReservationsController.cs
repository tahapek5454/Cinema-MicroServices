using Cinema.Services.MovieAPI.Mapper;
using Cinema.Services.RezervationAPI.Models.Dtos;
using Cinema.Services.RezervationAPI.Models.Entities;
using Cinema.Services.RezervationAPI.Models.Request;
using Cinema.Services.RezervationAPI.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.RezervationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationService _rezervationService;

        public ReservationsController(IReservationService rezervationService)
        {
            _rezervationService = rezervationService;
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
            var rezervation = ObjectMapper.Mapper.Map<Reservation>(request);

            await _rezervationService.Table.AddAsync(rezervation);

            await _rezervationService.SaveChangesAsync();

            return Created("api/Rezervations/"+ rezervation.Id, ResponseDto<BlankDto>.Sucess(200));
        }



    }
}
