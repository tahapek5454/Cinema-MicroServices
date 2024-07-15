using Cinema.Services.BranchAPI.Mapper;
using Cinema.Services.BranchAPI.Models.Dtos;
using Cinema.Services.BranchAPI.Models.Entities;
using Cinema.Services.BranchAPI.Models.Requests;
using Cinema.Services.BranchAPI.Services.Abstract;
using Cinema.Services.BranchAPI.Services.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.BranchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;

        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCities()
        {
            var r = await _cityService.Table.ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<CityDto>>(r);

            return Ok(ResponseDto<List<CityDto>>.Sucess(result, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetCities([FromQuery] int page, [FromQuery] int size)
        {
            var r = await _cityService.Table
                                        .Skip((page - 1) * size).Take(size).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<CityDto>>(r);

            return Ok(ResponseDto<List<CityDto>>.Sucess(result, 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById([FromRoute] int id)
        {
            var r = await _cityService.Table
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (r is null)
                throw new Exception("Şehir bulunamadı.");

            var result = ObjectMapper.Mapper.Map<CityDto>(r);

            return Ok(ResponseDto<CityDto>.Sucess(result, 200));
        }

        [HttpPost]
        public async Task<IActionResult> AddCity([FromBody] AddCityRequest request)
        {
            var r = ObjectMapper.Mapper.Map<City>(request);

            await _cityService.Table.AddAsync(r);
            await _cityService.SaveChangesAsync();

            return Created("api/Cities/GetCityById/" + r.Id, ResponseDto<BlankDto>.Sucess(201));
        }
    }
}
