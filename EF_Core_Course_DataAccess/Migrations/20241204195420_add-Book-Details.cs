using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Core_Course_DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addBookDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookDetila_Books_Book_Id",
                table: "BookDetila");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookDetila",
                table: "BookDetila");

            migrationBuilder.RenameTable(
                name: "BookDetila",
                newName: "bookDetilas");

            migrationBuilder.RenameIndex(
                name: "IX_BookDetila_Book_Id",
                table: "bookDetilas",
                newName: "IX_bookDetilas_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_bookDetilas",
                table: "bookDetilas",
                column: "BookDetila_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_bookDetilas_Books_Book_Id",
                table: "bookDetilas",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_bookDetilas_Books_Book_Id",
                table: "bookDetilas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_bookDetilas",
                table: "bookDetilas");

            migrationBuilder.RenameTable(
                name: "bookDetilas",
                newName: "BookDetila");

            migrationBuilder.RenameIndex(
                name: "IX_bookDetilas_Book_Id",
                table: "BookDetila",
                newName: "IX_BookDetila_Book_Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookDetila",
                table: "BookDetila",
                column: "BookDetila_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BookDetila_Books_Book_Id",
                table: "BookDetila",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "BookId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
