using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WasteManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class AddKantspildAndInternalReuse : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "WasteTypes",
                columns: new[] { "WasteTypeId", "Category", "Name" },
                values: new object[,]
                {
                    { 4, "Edge waste", "Kantspild" },
                    { 5, "Reused internally", "InternalReuse" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "WasteTypes",
                keyColumn: "WasteTypeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "WasteTypes",
                keyColumn: "WasteTypeId",
                keyValue: 5);
        }
    }
}
