using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace FestivalShoppingApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [EnableRateLimiting("Default")]
    public class ShoppingListController : ControllerBase
    {
        private readonly IShoppingListService _shoppingListService;
        public ShoppingListController(IShoppingListService shoppingListService)
        {
            _shoppingListService = shoppingListService;
        }
        
        [HttpPost(Name = "Create")]
        [EnableRateLimiting("Create-New-List")]
        public async Task<ActionResult<ShoppingListDto>> CreateNewShoppingList()
            => await _shoppingListService.CreateShoppingList();
        
        [HttpGet("{guid}")]
        public async Task<ActionResult<ShoppingListDto>> Get(Guid guid)
        {
            var shoppingList = await _shoppingListService.GetShoppingList(guid);
    
            if (shoppingList == null)
            {
                return NotFound();
            }

            return shoppingList;
        }

        [HttpPost("{guid}/AddItem")]
        public async Task<ActionResult> AddItem(Guid guid, NewItemRequest itemRequest)
        {
            var success = await _shoppingListService.AddItem(guid, itemRequest);
            if (!success)
            {
                return StatusCode(500, "UnknownError");
            }
        
            return Ok();
        }
    }
}
