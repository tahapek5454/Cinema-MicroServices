using Cinema.Services.MovieAPI.Mapper;
using Cinema.Services.RezervationAPI.Models.Dtos;
using Cinema.Services.RezervationAPI.Models.Entities;
using Cinema.Services.RezervationAPI.Service.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.RezervationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RezervationsController : ControllerBase
    {
        private readonly IRezervationService _rezervationService;

        public RezervationsController(IRezervationService rezervationService)
        {
            _rezervationService = rezervationService;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetRezervationById([FromRoute] int id)
        {
            var rezervation = await _rezervationService.Table.FirstOrDefaultAsync(x => x.Id == id);

            if (rezervation is null)
                throw new Exception("Rezervasyon bulunamadı");

            var rezervationDto = ObjectMapper.Mapper.Map<RezervationDto>(rezervation);

            return Ok(ResponseDto<RezervationDto>.Sucess(rezervationDto, 200));
        }



        [HttpPost]
        public async Task<IActionResult> CreateRezervation([FromBody] RezervationDto rezervationDto)
        {
            var rezervation = ObjectMapper.Mapper.Map<Rezervation>(rezervationDto);

            await _rezervationService.Table.AddAsync(rezervation);

            await _rezervationService.SaveChangesAsync();

            return Created("api/Rezervations/"+ rezervation.Id, ResponseDto<BlankDto>.Sucess(200));
        }



    }
}
