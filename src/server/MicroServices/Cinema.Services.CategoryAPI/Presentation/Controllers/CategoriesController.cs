using Cinema.Services.CategoryAPI.Application.Dtos.Categories;
using Cinema.Services.CategoryAPI.Application.Mapper;
using Cinema.Services.CategoryAPI.Application.Services.Abstract;
using Cinema.Services.CategoryAPI.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Models.Dtos;

namespace Cinema.Services.CategoryAPI.Presentation.Controllers
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

        [HttpPost, Authorize(Roles = "admin")]
        public async Task<IActionResult> AddGategory([FromBody] AddCategoryDto addCategoryDto)
        {
            var newCategory = ObjectMapper.Mapper.Map<Category>(addCategoryDto);

            await _categoryService.Table.AddAsync(newCategory);

            await _categoryService.SaveChangesAsync();

            return Created($"GetMovieById/{newCategory.Id}", ResponseDto<BlankDto>.Sucess(200));
        }

        [HttpPut, Authorize(Roles = "admin")]
        public async Task<IActionResult> UpdateGategory([FromBody] UpdateCategoryDto updateCategoryDto)
        {
            var updatedCategory = ObjectMapper.Mapper.Map<Category>(updateCategoryDto);

            _categoryService.Table.Update(updatedCategory);

            await _categoryService.SaveChangesAsync();

            return Ok(ResponseDto<BlankDto>.Sucess(200));
        }

        [HttpDelete("{id}"), Authorize(Roles = "admin")]
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
