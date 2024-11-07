using Cinema.Services.CategoryAPI.Application.Commands.Categories.AddGategory;
using Cinema.Services.CategoryAPI.Application.Commands.Categories.RemoveGategory;
using Cinema.Services.CategoryAPI.Application.Commands.Categories.UpdateGategory;
using Cinema.Services.CategoryAPI.Application.Queries.Categories.GetAllCategories;
using Cinema.Services.CategoryAPI.Application.Queries.Categories.GetCategoriesWithPagination;
using Cinema.Services.CategoryAPI.Application.Queries.Categories.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cinema.Services.CategoryAPI.Presentation.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoriesController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetCategoryById([FromRoute] GetCategoryByIdRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoriesWithPagination([FromQuery] GetCategoriesWithPaginationRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategories([FromQuery] GetAllCategoriesRequest request)
        {
            var r = await _mediator.Send(request);

            return Ok(r);
        }

        [HttpPost, Authorize(Roles = "admin")]
        public async Task<IActionResult> AddCategory([FromBody] AddCategoryRequest request)
        {
            _ = await _mediator.Send(request);

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGategory([FromBody] UpdateGategoryRequest request)
        {
            _ = await _mediator.Send(request);

            return Ok();
        }

        [HttpDelete("{Id}"), Authorize(Roles = "admin")]
        public async Task<IActionResult> RemoveGategory([FromRoute] RemoveGategoryRequest request)
        {
            _ = await _mediator.Send(request);

            return Ok();
        }
    }
}
