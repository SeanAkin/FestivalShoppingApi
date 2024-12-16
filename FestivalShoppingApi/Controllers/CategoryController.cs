using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace FestivalShoppingApi.Controllers;

[ApiController]
[Route("[controller]")]
[EnableRateLimiting("Default")]
public class CategoryController : BaseController
{
    private readonly ICategoryService _categoryService;
    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    [HttpPost("{guid}/Create")]
    public async Task<ActionResult<Result>> CreateCategory(Guid guid, NewCategoryRequest newCategoryRequest)
        => ResolveResult(await _categoryService.CreateCategory(guid, newCategoryRequest));

    [HttpDelete("{guid}/Delete")]
    public async Task<ActionResult<Result>> DeleteCategory(Guid guid)
        => ResolveResult(await _categoryService.DeleteCategory(guid));
}