using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.RequestModels;

namespace FestivalShoppingApi.Domain.Contracts;

public interface IShoppingListService
{
    Task<ShoppingListDto?> GetShoppingList(Guid guid);
    Task<ShoppingListDto> CreateShoppingList();
    Task<bool> AddItem(Guid guid, NewItemRequest newItemRequest);
    Task<bool> DoesShoppingListExist(Guid guid);
}