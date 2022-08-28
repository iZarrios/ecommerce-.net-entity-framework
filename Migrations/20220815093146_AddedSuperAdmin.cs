using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electronics_shop_mvc_1.Migrations
{
    public partial class AddedSuperAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1659682413041-4fe07d26c872?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIyMDI2Mg&ixlib=rb-1.2.1&q=80&w=750");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1657779189956-0ce6ebfa74b9?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIyMDMwOA&ixlib=rb-1.2.1&q=80&w=750");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1657718237047-1083c4a59790?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIxOTc4OQ&ixlib=rb-1.2.1&q=80&w=750");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1657718237047-1083c4a59790?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIxOTc4OQ&ixlib=rb-1.2.1&q=80&w=750");
        }
    }
}
