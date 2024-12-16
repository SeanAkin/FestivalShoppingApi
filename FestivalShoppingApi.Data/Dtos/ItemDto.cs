namespace FestivalShoppingApi.Data.Dtos;

public record ItemDto
{
    public Guid ItemId { get; init; }
    public string Name { get; init; } = string.Empty;
    public string? Url { get; init; }
    public bool Essential { get; init; }
    
}