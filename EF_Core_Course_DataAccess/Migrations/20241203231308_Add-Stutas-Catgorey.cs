using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Course_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStutasCatgorey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "SubCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "SubCategories");
        }
    }
}
