using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lesson9.Migrations
{
    /// <inheritdoc />
    public partial class EditEmployeeName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "NameTest");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "NameTest",
                table: "Employees",
                newName: "Name");
        }
    }
}
