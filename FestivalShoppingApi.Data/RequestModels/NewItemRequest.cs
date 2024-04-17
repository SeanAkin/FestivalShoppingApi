namespace FestivalShoppingApi.Data.RequestModels;

public class NewItemRequest
{
    public string Name { get; set; } = string.Empty;
    public string? Url { get; set; }
    public bool Essential { get; set; }
    public int CategoryId { get; set; }
}