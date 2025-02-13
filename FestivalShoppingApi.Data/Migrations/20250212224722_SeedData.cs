using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FestivalShoppingApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ShoppingLists",
                columns: new[] { "GuidId", "Name" },
                values: new object[] { new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "Festival Shopping List" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name", "ShoppingListId" },
                values: new object[,]
                {
                    { 1, "Camping Gear", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d") },
                    { 2, "Food & Drinks", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d") },
                    { 3, "Clothing", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d") }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "ItemId", "CategoryId", "Essential", "Name", "ShoppingListId", "Url" },
                values: new object[,]
                {
                    { new Guid("28262b00-0905-47c5-b300-77a0193f373e"), 3, true, "Rain Jacket", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "https://example.com/rain-jacket" },
                    { new Guid("776edefb-31d3-4bea-82a1-2736f8d5f4e3"), 2, false, "Snacks", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "https://example.com/snacks" },
                    { new Guid("b18c6e30-bfb7-4be0-b26f-9e33eea09e72"), 1, false, "Camping Stove", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "https://example.com/camping-stove" },
                    { new Guid("b554f9b0-2856-43c6-ae6f-3d2d62b22572"), 1, true, "Sleeping Bag", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "https://example.com/sleeping-bag" },
                    { new Guid("c118e240-7b43-487f-aa57-5523d3686d61"), 3, false, "Sunglasses", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "https://example.com/sunglasses" },
                    { new Guid("d2105fde-3967-4366-ac97-9f26432f5484"), 3, true, "Hiking Boots", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "https://example.com/hiking-boots" },
                    { new Guid("d537a14a-487a-4947-bd83-cddfa8c040e2"), 1, true, "Tent", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "https://example.com/tent" },
                    { new Guid("dc76dd85-9c9b-4f46-a02f-4104683a6c53"), 2, true, "Water Bottles", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "https://example.com/water-bottles" },
                    { new Guid("ef5c5204-4ae8-4591-a3d3-d7769225b4fa"), 2, true, "Canned Food", new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"), "https://example.com/canned-food" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("28262b00-0905-47c5-b300-77a0193f373e"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("776edefb-31d3-4bea-82a1-2736f8d5f4e3"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("b18c6e30-bfb7-4be0-b26f-9e33eea09e72"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("b554f9b0-2856-43c6-ae6f-3d2d62b22572"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("c118e240-7b43-487f-aa57-5523d3686d61"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("d2105fde-3967-4366-ac97-9f26432f5484"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("d537a14a-487a-4947-bd83-cddfa8c040e2"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("dc76dd85-9c9b-4f46-a02f-4104683a6c53"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "ItemId",
                keyValue: new Guid("ef5c5204-4ae8-4591-a3d3-d7769225b4fa"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ShoppingLists",
                keyColumn: "GuidId",
                keyValue: new Guid("53fb2f13-37b4-41aa-a7cb-ccf484500b6d"));
        }
    }
}
