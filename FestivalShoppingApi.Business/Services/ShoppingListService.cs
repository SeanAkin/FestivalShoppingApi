using FestivalShoppingApi.Data;
using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.RequestModels;
using FestivalShoppingApi.Domain.Contracts;
using Microsoft.EntityFrameworkCore;

namespace FestivalShoppingApi.Domain.Services;

public class ShoppingListService : IShoppingListService
{
    private readonly FestivalShoppingContext _context;
    public ShoppingListService(FestivalShoppingContext context)
    {
        _context = context;
    }
    
    public async Task<ShoppingListDto?> GetShoppingList(Guid shoppingListId)
    {
        var shoppingList = await _context.ShoppingLists
            .Include(sl => sl.Categories)
            .ThenInclude(c => c.Items)
            .FirstOrDefaultAsync(sl => sl.GuidId == shoppingListId);

        return shoppingList?.ConvertToDto();
    }

    public async Task<ShoppingListDto> CreateShoppingList()
    {
        var newShoppingList = new ShoppingList();
        
        await _context.AddAsync(newShoppingList);
        await _context.SaveChangesAsync();

        return newShoppingList.ConvertToDto();
    }

    public async Task<bool> AddItem(Guid guid, NewItemRequest newItemRequest)
    {
        var shoppingList = await _context.ShoppingLists
            .Include(sl => sl.Categories)
            .FirstOrDefaultAsync(x => x.GuidId == guid);
        if (shoppingList is null || !shoppingList.Categories.Any(x => x.CategoryId == newItemRequest.CategoryId))
        {
            return false;
        }

        var itemToAdd = new Item()
        {
            Name = newItemRequest.Name,
            Url = newItemRequest.Url,
            Essential = newItemRequest.Essential,
            CategoryId = newItemRequest.CategoryId,
            ShoppingListId = guid
        };

        shoppingList.Items.Add(itemToAdd);
        await _context.SaveChangesAsync();

        return true;
    }
    
    public async Task<bool> DoesShoppingListExist(Guid guid)
        => await _context.ShoppingLists.AnyAsync(x => x.GuidId == guid);
}