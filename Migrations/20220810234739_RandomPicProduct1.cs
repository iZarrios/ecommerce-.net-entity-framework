using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electronics_shop_mvc_1.Migrations
{
    public partial class RandomPicProduct1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1658387898335-97235be0336a?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDE3NTI1Nw&ixlib=rb-1.2.1&q=80&w=750");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1658387898335-97235be0336a?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDE3NTI1Nw&ixlib=rb-1.2.1&q=80&w=750");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1658387898335-97235be0336a?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDE3NTI1Nw&ixlib=rb-1.2.1&q=80&w=750");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
