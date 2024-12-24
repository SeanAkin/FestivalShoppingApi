using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace FestivalShoppingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingListController(IShoppingListService shoppingListService) : BaseController
{
    [HttpPost(Name = "Create")]
    [EnableRateLimiting("Create-New-List")]
    public async Task<ActionResult<Result<Guid>>> CreateNewShoppingList(string name)
        => ResolveResult(await shoppingListService.CreateShoppingList(name));
        
    [HttpGet("{guid}")]
    public async Task<ActionResult<Result<ShoppingListDto?>>> Get(Guid guid)
        => ResolveResult(await shoppingListService.GetShoppingList(guid));
}