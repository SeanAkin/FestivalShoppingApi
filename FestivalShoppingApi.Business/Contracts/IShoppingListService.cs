using FestivalShoppingApi.Common.Models;
using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.RequestModels;

namespace FestivalShoppingApi.Domain.Contracts;

public interface IShoppingListService
{
    Task<Result<ShoppingListDto?>> GetShoppingList(Guid guid);
    Task<Result<Guid>> CreateShoppingList(string name);
    Task<Result> DeleteShoppingList(Guid guid);
    Task<bool> Exists(Guid guid);
}