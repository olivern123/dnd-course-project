using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WasteManagement.API.Migrations
{
    /// <inheritdoc />
    public partial class AddUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HandlingMethods",
                columns: table => new
                {
                    HandlingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Method = table.Column<string>(type: "TEXT", nullable: false),
                    CostPerTon = table.Column<decimal>(type: "TEXT", nullable: false),
                    CO2FactorPerTon = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HandlingMethods", x => x.HandlingId);
                });

            migrationBuilder.CreateTable(
                name: "Sites",
                columns: table => new
                {
                    SiteId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.SiteId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Role = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WasteTypes",
                columns: table => new
                {
                    WasteTypeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Category = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteTypes", x => x.WasteTypeId);
                });

            migrationBuilder.CreateTable(
                name: "WasteEntries",
                columns: table => new
                {
                    EntryId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiteId = table.Column<int>(type: "INTEGER", nullable: false),
                    WasteTypeId = table.Column<int>(type: "INTEGER", nullable: false),
                    HandlingId = table.Column<int>(type: "INTEGER", nullable: false),
                    HandlingMethodHandlingId = table.Column<int>(type: "INTEGER", nullable: true),
                    QuantityKg = table.Column<decimal>(type: "TEXT", nullable: false),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WasteEntries", x => x.EntryId);
                    table.ForeignKey(
                        name: "FK_WasteEntries_HandlingMethods_HandlingMethodHandlingId",
                        column: x => x.HandlingMethodHandlingId,
                        principalTable: "HandlingMethods",
                        principalColumn: "HandlingId");
                    table.ForeignKey(
                        name: "FK_WasteEntries_Sites_SiteId",
                        column: x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "SiteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WasteEntries_WasteTypes_WasteTypeId",
                        column: x => x.WasteTypeId,
                        principalTable: "WasteTypes",
                        principalColumn: "WasteTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "HandlingMethods",
                columns: new[] { "HandlingId", "CO2FactorPerTon", "CostPerTon", "Method" },
                values: new object[,]
                {
                    { 1, 2500m, 150m, "Incineration" },
                    { 2, 500m, 80m, "Recycling" }
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "SiteId", "Location", "Name" },
                values: new object[,]
                {
                    { 1, "Denmark", "Convert" },
                    { 2, "Norway", "Innvik" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Role", "Username" },
                values: new object[,]
                {
                    { 1, "admin123", "Admin", "admin" },
                    { 2, "user123", "User", "user" }
                });

            migrationBuilder.InsertData(
                table: "WasteTypes",
                columns: new[] { "WasteTypeId", "Category", "Name" },
                values: new object[,]
                {
                    { 1, "Fiber", "Yarn leftovers" },
                    { 2, "Fabric", "Fabric scraps" },
                    { 3, "Cardboard/Plastic", "Packaging" }
                });

            migrationBuilder.InsertData(
                table: "WasteEntries",
                columns: new[] { "EntryId", "Date", "HandlingId", "HandlingMethodHandlingId", "QuantityKg", "SiteId", "WasteTypeId" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 200m, 1, 1 },
                    { 2, new DateTime(2025, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, 150m, 1, 2 },
                    { 3, new DateTime(2025, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, 300m, 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_WasteEntries_HandlingMethodHandlingId",
                table: "WasteEntries",
                column: "HandlingMethodHandlingId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteEntries_SiteId",
                table: "WasteEntries",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_WasteEntries_WasteTypeId",
                table: "WasteEntries",
                column: "WasteTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WasteEntries");

            migrationBuilder.DropTable(
                name: "HandlingMethods");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "WasteTypes");
        }
    }
}
