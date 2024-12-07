using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Course_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddStutasAutherPuplisher : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Publishers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 1,
                column: "Status",
                value: 0);

            migrationBuilder.UpdateData(
                table: "Publishers",
                keyColumn: "Publisher_Id",
                keyValue: 2,
                column: "Status",
                value: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Publishers");
        }
    }
}
