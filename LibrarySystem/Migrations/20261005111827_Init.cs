using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categories_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_members", x => x.Id);
                    table.ForeignKey(
                        name: "FK_members_members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsAvilable = table.Column<bool>(type: "bit", nullable: false),
                    CategorydId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_books_categories_CategorydId",
                        column: x => x.CategorydId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "borrowings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BorrowDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: false),
                    BookId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_borrowings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_borrowings_books_BookId",
                        column: x => x.BookId,
                        principalTable: "books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_borrowings_members_MemberId",
                        column: x => x.MemberId,
                        principalTable: "members",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "categories",
                columns: new[] { "Id", "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, null, "Programming and software\r\ndevelopment books", "Programming" },
                    { 2, null, "Database and data management\r\n\r\nbooks", "DataBase" }
                });

            migrationBuilder.InsertData(
                table: "members",
                columns: new[] { "Id", "Email", "MemberId", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "ahmed@example.com", null, "Ahmed Hassan ", "01198765432" },
                    { 2, "Sara@example.com", null, "Sara Mohamed ", "01012345678" }
                });

            migrationBuilder.InsertData(
                table: "books",
                columns: new[] { "Id", "Author", "CategorydId", "ISBN", "IsAvilable", "Price", "Title" },
                values: new object[,]
                {
                    { 1, "John Smith", 1, "ISBN001", true, 450m, "C++ Basics " },
                    { 2, "Sarah Ali ", 2, "ISBN002", false, 500m, "Sql Fundementals" }
                });

            migrationBuilder.InsertData(
                table: "borrowings",
                columns: new[] { "Id", "BookId", "BorrowDate", "MemberId", "ReturnDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 9, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2026, 9, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2026, 9, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_books_CategorydId",
                table: "books",
                column: "CategorydId");

            migrationBuilder.CreateIndex(
                name: "IX_books_ISBN",
                table: "books",
                column: "ISBN",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_books_Price",
                table: "books",
                column: "Price",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_borrowings_BookId",
                table: "borrowings",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_borrowings_MemberId",
                table: "borrowings",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_CategoryId",
                table: "categories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_categories_Name",
                table: "categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_members_Email",
                table: "members",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_members_MemberId",
                table: "members",
                column: "MemberId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "borrowings");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "members");

            migrationBuilder.DropTable(
                name: "categories");
        }
    }
}
