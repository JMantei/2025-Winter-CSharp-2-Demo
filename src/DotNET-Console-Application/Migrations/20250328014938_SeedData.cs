using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DotNET_Console_Application.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "classroom",
                columns: new[] { "id", "room_number" },
                values: new object[,]
                {
                    { -2, 2 },
                    { -1, 1 }
                });

            migrationBuilder.InsertData(
                table: "student",
                columns: new[] { "id", "class_id", "first_name", "last_name", "middle_name" },
                values: new object[,]
                {
                    { -2, -2, "Jane", "Doe", "Joanne" },
                    { -1, -1, "John", "Doe", "Robert" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "student",
                keyColumn: "id",
                keyValue: -1);

            migrationBuilder.DeleteData(
                table: "classroom",
                keyColumn: "id",
                keyValue: -2);

            migrationBuilder.DeleteData(
                table: "classroom",
                keyColumn: "id",
                keyValue: -1);
        }
    }
}
