using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace electronics_shop_mvc_1.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "MultiUnitDiscount", "Name", "Price", "Quantity", "RegistrationDiscount" },
                values: new object[] { 1, 101, "test11", 50m, "test1", 1001m, 101, 50m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "MultiUnitDiscount", "Name", "Price", "Quantity", "RegistrationDiscount" },
                values: new object[] { 2, 102, "test22", 50m, "test2", 1002m, 102, 50m });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "MultiUnitDiscount", "Name", "Price", "Quantity", "RegistrationDiscount" },
                values: new object[] { 3, 103, "test33", 50m, "test3", 1003m, 103, 50m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "ProductId",
                keyValue: 3);
        }
    }
}
