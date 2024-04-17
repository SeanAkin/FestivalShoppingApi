using FestivalShoppingApi.Data;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;

namespace FestivalShoppingApi.Domain.Services;

public class CategoryService : ICategoryService
{
    private readonly FestivalShoppingContext _context;
    private readonly IShoppingListService _shoppingListService;
    public CategoryService(FestivalShoppingContext context, IShoppingListService shoppingListService)
    {
        _context = context;
        _shoppingListService = shoppingListService;
    }

    public async Task<bool> CreateCategory(Guid guid, NewCategoryRequest newCategoryRequest)
    {
        var shoppingListExists = await _shoppingListService.DoesShoppingListExist(guid);
        if (shoppingListExists is false) return false;
    
        var categoryToAdd = new Category()
        {
            Name = newCategoryRequest.Name,
            ShoppingListId = guid
        };
    
        await _context.AddAsync(categoryToAdd);
        await _context.SaveChangesAsync();
    
        return true;
    }
}