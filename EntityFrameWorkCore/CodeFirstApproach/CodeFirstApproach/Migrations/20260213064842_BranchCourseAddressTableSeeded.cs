using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CodeFirstApproach.Migrations
{
    /// <inheritdoc />
    public partial class BranchCourseAddressTableSeeded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "State", "StudentId" },
                values: new object[,]
                {
                    { 1, "Vaishali", "India", "Bihar", 1 },
                    { 2, "Lalaganj", "India", "UtterPradesh", 2 },
                    { 3, "Patna", "India", "Bihar", 3 },
                    { 4, "Vaishali", "India", "Bihar", 4 }
                });

            migrationBuilder.InsertData(
                table: "Branches",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Maheru" },
                    { 2, "Jalandhar" },
                    { 3, "Phaghwara" }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "CourseId", "CourseName" },
                values: new object[,]
                {
                    { 1, "Mathematics" },
                    { 2, "Science" },
                    { 3, "Hindi" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Branches",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "CourseId",
                keyValue: 3);
        }
    }
}
