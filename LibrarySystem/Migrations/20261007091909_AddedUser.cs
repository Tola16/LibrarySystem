using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibrarySystem.Migrations
{
    /// <inheritdoc />
    public partial class AddedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_members_members_MemberId",
                table: "members");

            migrationBuilder.DropIndex(
                name: "IX_members_MemberId",
                table: "members");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "members");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PassWordHash = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Name", "PassWordHash" },
                values: new object[,]
                {
                    { 1, "Dola", "SecretPass" },
                    { 2, "Adel", "SecretPass2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_users_Name",
                table: "users",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "members",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "members",
                keyColumn: "Id",
                keyValue: 1,
                column: "MemberId",
                value: null);

            migrationBuilder.UpdateData(
                table: "members",
                keyColumn: "Id",
                keyValue: 2,
                column: "MemberId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_members_MemberId",
                table: "members",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_members_members_MemberId",
                table: "members",
                column: "MemberId",
                principalTable: "members",
                principalColumn: "Id");
        }
    }
}
