using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FestivalShoppingApi.Data.Models;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    [ForeignKey("ShoppingList")]
    public Guid ShoppingListId { get; set; }
    public virtual ShoppingList ShoppingList { get; set; }  
    public virtual List<Item> Items { get; set; } = new List<Item>();
}