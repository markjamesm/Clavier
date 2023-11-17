using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprocket.Migrations.Page
{
    /// <inheritdoc />
    public partial class AddPageBody : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountId",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Pages",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "Body",
                table: "Pages",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Body",
                table: "Pages");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Pages",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "AccountId",
                table: "Pages",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
