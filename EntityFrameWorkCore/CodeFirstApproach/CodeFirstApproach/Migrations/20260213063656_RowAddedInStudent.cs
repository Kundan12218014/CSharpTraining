using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeFirstApproach.Migrations
{
    /// <inheritdoc />
    public partial class RowAddedInStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BranchId", "Email", "Name", "PhoneNumber", "StudentId" },
                values: new object[,]
                {
                    { 1, 1, "Kundan@gmail.com", "Kundan", 123456534, 0 },
                    { 2, 2, "Nikhil@gmail.com", "Nikhil", 345342342, 0 },
                    { 3, 3, "Gaurav@gmail.com", "Gaurav", 892873433, 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
