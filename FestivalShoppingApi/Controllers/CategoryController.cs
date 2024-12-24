using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace FestivalShoppingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController(ICategoryService categoryService) : BaseController
{
    [HttpPost("Create")]
    public async Task<ActionResult<Result>> CreateCategory(NewCategoryRequest newCategoryRequest)
        => ResolveResult(await categoryService.CreateCategory(newCategoryRequest));

    [HttpDelete("{guid:guid}/Delete")]
    public async Task<ActionResult<Result>> DeleteCategory(Guid guid)
        => ResolveResult(await categoryService.DeleteCategory(guid));
}