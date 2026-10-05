using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class Edit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_categories_categories_CategoryId",
                table: "categories");

            migrationBuilder.DropIndex(
                name: "IX_categories_CategoryId",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "categories");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "categories",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "CategoryId",
                value: null);

            migrationBuilder.UpdateData(
                table: "categories",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_categories_CategoryId",
                table: "categories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_categories_categories_CategoryId",
                table: "categories",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }
    }
}
