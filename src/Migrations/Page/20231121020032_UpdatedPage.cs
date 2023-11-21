using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprocket.Migrations.Page
{
    /// <inheritdoc />
    public partial class UpdatedPage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Author",
                table: "Pages",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Author",
                table: "Pages");
        }
    }
}
