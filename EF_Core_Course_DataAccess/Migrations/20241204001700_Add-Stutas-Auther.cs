using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Course_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStutasAuther : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Authers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Authers");
        }
    }
}
