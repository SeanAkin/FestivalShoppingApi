using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestivalShoppingApi.Data.Models;

public record Item
{
    [Key]
    public int ItemId { get; set; }

    [Required] 
    [MaxLength(100)] 
    public string Name { get; set; } = string.Empty;
    public string? Url { get; set; }
    public bool Essential { get; set; }
    [ForeignKey("ShoppingList")]
    public Guid ShoppingListId { get; set; }
    public virtual ShoppingList ShoppingList { get; set; }  
    [ForeignKey("Category")]
    public int CategoryId { get; set; }  
    public virtual Category Category { get; set; }  
}
