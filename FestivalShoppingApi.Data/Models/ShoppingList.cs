using System.ComponentModel.DataAnnotations;
using FestivalShoppingApi.Data.Dtos;

namespace FestivalShoppingApi.Data.Models;

public class ShoppingList
{
    [Key]
    public Guid GuidId { get; set; }
    public virtual List<Category> Categories { get; set; } = [];
    public virtual List<Item> Items { get; set; } = [];
}

public static class ShoppingListExtensions
{
    public static ShoppingListDto ConvertToDto(this ShoppingList shoppingList)
    {
        return new ShoppingListDto
        {
            ShoppingListId = shoppingList.GuidId,
            Categories = shoppingList.Categories.Select(c => new CategoryDto()
            {
                CategoryId = c.CategoryId,
                Name = c.Name,
                Items = c.Items.Select(i => new ItemDto
                {
                    ItemId = i.ItemId,
                    Name = i.Name,
                    Url = i.Url,
                    Essential = i.Essential
                }).ToList()
            }).ToList()
        };
    }
}