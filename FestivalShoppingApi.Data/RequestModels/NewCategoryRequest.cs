namespace FestivalShoppingApi.Data.RequestModels;

public class NewCategoryRequest
{
    public string Name { get; set; } = string.Empty;
    public Guid ShoppingListId { get; set; }
}