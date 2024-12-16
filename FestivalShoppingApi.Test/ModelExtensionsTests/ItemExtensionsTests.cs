using FestivalShoppingApi.Data.Dtos;
using FestivalShoppingApi.Data.Models;
using FluentAssertions;

namespace FestivalShoppingApi.Test.ModelExtensionsTests;

public class ItemExtensionsTests
{
    [Fact]
    public void Item_ConvertToDto_CorrectlyWithAllProperties()
    {
        var testItem = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Test Item",
            Url = "https://example.com/item",
            Essential = true,
            CategoryId = 1,
            Category = new Category { CategoryId = 1, Name = "Test Category" }
        };

        var expectedDto = new ItemDto
        {
            ItemId = testItem.ItemId,
            Name = testItem.Name,
            Url = testItem.Url,
            Essential = testItem.Essential
        };

        var actualDto = testItem.ConvertToDto();

        actualDto.Should().BeEquivalentTo(expectedDto);
    }

    [Fact]
    public void Item_ConvertToDto_CorrectlyWithoutUrl()
    {
        var testItem = new Item
        {
            ItemId = Guid.NewGuid(),
            Name = "Test Item Without URL",
            Essential = false,
            CategoryId = 1,
            Category = new Category { CategoryId = 1, Name = "Test Category" }
        };

        var expectedDto = new ItemDto
        {
            ItemId = testItem.ItemId,
            Name = testItem.Name,
            Url = null,
            Essential = testItem.Essential
        };

        var actualDto = testItem.ConvertToDto();

        actualDto.Should().BeEquivalentTo(expectedDto);
    }
}