using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstApproach.Migrations
{
    /// <inheritdoc />
    public partial class BranchCourseAddressTableSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "Id",
                keyValue: 4);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "Id", "City", "Country", "State", "StudentId" },
                values: new object[] { 4, "Vaishali", "India", "Bihar", 4 });
        }
    }
}
