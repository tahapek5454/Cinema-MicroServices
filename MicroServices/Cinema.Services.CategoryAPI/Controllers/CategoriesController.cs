using Cinema.Services.CategoryAPI.Mapper;
using Cinema.Services.CategoryAPI.Models.Dtos.Categories;
using Cinema.Services.CategoryAPI.Models.Entities;
using Cinema.Services.CategoryAPI.Services.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.CategoryAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController(ICategoryService _categoryService) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGategoryById([FromRoute] int id)
        {
            var category = await _categoryService.Table.FirstOrDefaultAsync(x => x.Id == id);

            if (category is null)
                throw new Exception("Category is not found");

            var categoryDto = ObjectMapper.Mapper.Map<CategoryDto>(category);

            return Ok(ResponseDto<CategoryDto>.Sucess(categoryDto, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetGategoriesWithPagination([FromQuery] PaginationDto paginationDto)
        {
            var categories = await _categoryService.Table
                .Skip((paginationDto.Page - 1) * paginationDto.Size)
                .Take(paginationDto.Size)
                .ToListAsync();

            var categoryDtos = ObjectMapper.Mapper.Map<List<CategoryDto>>(categories);

            return Ok(ResponseDto<List<CategoryDto>>.Sucess(categoryDtos, 200));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGategories()
        {
            var categories = await _categoryService.Table.ToListAsync();

            var categoryDtos = ObjectMapper.Mapper.Map<List<CategoryDto>>(categories);

            return Ok(ResponseDto<List<CategoryDto>>.Sucess(categoryDtos, 200));
        }

        [HttpPost]
        public async Task<IActionResult> AddGategory([FromBody] AddCategoryDto addCategoryDto)
        {
            var newCategory = ObjectMapper.Mapper.Map<Category>(addCategoryDto);

            await _categoryService.Table.AddAsync(newCategory);

            await _categoryService.SaveChangesAsync();

            return Created($"GetMovieById/{newCategory.Id}", ResponseDto<BlankDto>.Sucess(200));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var updatedCategory = ObjectMapper.Mapper.Map<Category>(updateCategoryDto);

            _categoryService.Table.Update(updatedCategory);

            await _categoryService.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(200));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveGategory([FromRoute] int id)
        {
            var movie = await _categoryService.Table.FirstOrDefaultAsync(x => x.Id == id);

            if (movie is null)
                throw new Exception("Category is not found");

            _categoryService.Table.Remove(movie);

            await _categoryService.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(200));
        }
    }
}
