using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electronics_shop_mvc_1.Migrations
{
    public partial class AddedOrders1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ProductId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.OrderId);
                    table.ForeignKey(
                        name: "FK_Orders_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1657718237047-1083c4a59790?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIxOTc4OQ&ixlib=rb-1.2.1&q=80&w=750");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1657718237047-1083c4a59790?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIxOTc4OQ&ixlib=rb-1.2.1&q=80&w=750");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3,
                column: "ProductImage",
                value: "https://images.unsplash.com/photo-1657718237047-1083c4a59790?crop=entropy&cs=tinysrgb&fit=crop&fm=jpg&h=750&ixid=MnwxfDB8MXxyYW5kb218MHx8fHx8fHx8MTY2MDIxOTc4OQ&ixlib=rb-1.2.1&q=80&w=750");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductId",
                table: "Orders",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Orders");

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
    }
}
