using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electronics_shop_mvc_1.Migrations
{
    public partial class SeedCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 101, "lcd" });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 102, "tv" });

            migrationBuilder.InsertData(
                table: "ProductCategory",
                columns: new[] { "CategoryId", "Name" },
                values: new object[] { 103, "soundsystem" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "CategoryId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "CategoryId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "ProductCategory",
                keyColumn: "CategoryId",
                keyValue: 103);
        }
    }
}
