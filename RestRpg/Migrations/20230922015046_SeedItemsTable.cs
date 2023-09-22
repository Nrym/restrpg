using Microsoft.EntityFrameworkCore.Migrations;

namespace RestRpg.Migrations
{
    public partial class SeedItemsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Name", "Price" },
                values: new object[] { 1, 3, "Small Mana potion", 20.0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Name", "Price" },
                values: new object[] { 2, 3, "Small Life potion", 20.0 });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Amount", "Name", "Price" },
                values: new object[] { 3, 3, "Light Mana potion", 55.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
