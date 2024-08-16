using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Requests;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.BranchAPI.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DitrictsController : ControllerBase
    {
        private readonly IDistrictService _districtService;

        public DitrictsController(IDistrictService districtService)
        {
            _districtService = districtService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDistricts()
        {
            var r = await _districtService.Table.ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<DistrictDto>>(r);

            return Ok(ResponseDto<List<DistrictDto>>.Sucess(result, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetDistricts([FromQuery] int page, [FromQuery] int size)
        {
            var r = await _districtService.Table
                                        .Skip((page - 1) * size).Take(size).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<DistrictDto>>(r);

            return Ok(ResponseDto<List<DistrictDto>>.Sucess(result, 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDistrictById([FromRoute] int id)
        {
            var r = await _districtService.Table
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (r is null)
                throw new Exception("İlçe bulunamadı.");

            var result = ObjectMapper.Mapper.Map<DistrictDto>(r);

            return Ok(ResponseDto<DistrictDto>.Sucess(result, 200));
        }

        [HttpPost]
        public async Task<IActionResult> AddDistrict([FromBody] AddDistrictRequest request)
        {
            var r = ObjectMapper.Mapper.Map<District>(request);

            await _districtService.Table.AddAsync(r);
            await _districtService.SaveChangesAsync();

            return Created("api/District/GetDistrictById/" + r.Id, ResponseDto<BlankDto>.Sucess(201));
        }
    }
}
