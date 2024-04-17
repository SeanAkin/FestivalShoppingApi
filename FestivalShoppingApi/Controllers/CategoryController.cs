using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace FestivalShoppingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost("{guid}/Create")]
    public async Task<ActionResult> CreateCategory(Guid guid, NewCategoryRequest newCategoryRequest)
    {
        var success = await _categoryService.CreateCategory(guid, newCategoryRequest);
        if (!success)
        {
            return BadRequest();
        }

        return Ok();
    }
}