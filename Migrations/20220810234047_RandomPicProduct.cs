using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electronics_shop_mvc_1.Migrations
{
    public partial class RandomPicProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductImage",
                value: "https://random.imagecdn.app/v1/image?width=750&height=750");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductImage",
                value: "https://random.imagecdn.app/v1/image?width=750&height=750");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ProductImage",
                value: "https://random.imagecdn.app/v1/image?width=750&height=750");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductImage",
                value: "1");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductImage",
                value: "2");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ProductImage",
                value: "3");
        }
    }
}
