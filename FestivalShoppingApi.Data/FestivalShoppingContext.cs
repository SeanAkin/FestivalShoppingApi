using FestivalShoppingApi.Data.Models;
using FestivalShoppingApi.Data.Seed;
using Microsoft.EntityFrameworkCore;

namespace FestivalShoppingApi.Data;

public class FestivalShoppingContext(DbContextOptions<FestivalShoppingContext> options) : DbContext(options)
{
    public DbSet<Item> Items { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        ShoppingListSeed.Seed(modelBuilder);
    }
}