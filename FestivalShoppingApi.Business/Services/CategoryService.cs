using System.Net;
using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;

namespace FestivalShoppingApi.Domain.Services;

public class CategoryService(FestivalShoppingContext context, IShoppingListService shoppingListService)
    : ICategoryService
{
    public async Task<Result> CreateCategory(NewCategoryRequest newCategoryRequest)
    {
        var shoppingListExists = await shoppingListService.Exists(newCategoryRequest.ShoppingListId);
        if (shoppingListExists is false)
        {
            return Result.FailureResult("Shopping list doesn't exist", HttpStatusCode.NotFound);
        }
    
        var categoryToAdd = new Category()
        {
            Name = newCategoryRequest.Name,
            ShoppingListId = newCategoryRequest.ShoppingListId
        };
    
        await context.AddAsync(categoryToAdd);
        await context.SaveChangesAsync();
    
        return Result.SuccessResult();
    }

    public async Task<Result> DeleteCategory(Guid guid)
    {
        var category = await context.Categories.FindAsync(guid);
        if (category is null)
        {
            return Result.FailureResult("Category doesn't exist", HttpStatusCode.NotFound);
        }
        
        context.Categories.Remove(category);
        await context.SaveChangesAsync();
        
        return Result.SuccessResult();
    }
}