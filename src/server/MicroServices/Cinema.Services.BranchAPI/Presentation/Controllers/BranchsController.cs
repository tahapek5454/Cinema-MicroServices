using Cinema.Services.BranchAPI.Application.Dtos;
using Cinema.Services.BranchAPI.Application.Mapper;
using Cinema.Services.BranchAPI.Application.Requests;
using Cinema.Services.BranchAPI.Application.Services.Abstract;
using Cinema.Services.BranchAPI.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.BranchAPI.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BranchsController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchsController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var r = await _branchService.Table.ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<BranchDto>>(r);

            return Ok(ResponseDto<List<BranchDto>>.Sucess(result, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetBranches([FromQuery] int page, [FromQuery] int size)
        {
            var r = await _branchService.Table
                                        .Skip((page - 1) * size).Take(size).ToListAsync();

            var result = ObjectMapper.Mapper.Map<List<BranchDto>>(r);

            return Ok(ResponseDto<List<BranchDto>>.Sucess(result, 200));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBrancheById([FromRoute] int id)
        {
            var r = await _branchService.Table
                                        .FirstOrDefaultAsync(x => x.Id == id);

            if (r is null)
                throw new Exception("Şube bulunamadı.");

            var result = ObjectMapper.Mapper.Map<BranchDto>(r);

            return Ok(ResponseDto<BranchDto>.Sucess(result, 200));
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody] AddBranchRequest request)
        {
            var r = ObjectMapper.Mapper.Map<Branch>(request);

            await _branchService.Table.AddAsync(r);
            await _branchService.SaveChangesAsync();

            return Created("api/Branchs/GetBrancheById/" + r.Id, ResponseDto<BlankDto>.Sucess(201));
        }

        // sonra guncelleme ve silme eklenir 
        // not: dinamik guncelleme
    }
}
