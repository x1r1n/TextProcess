using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextProcess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSourceTextModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Text",
                table: "SourceTexts",
                newName: "GenerationWords");

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "SourceTexts",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Content",
                table: "SourceTexts");

            migrationBuilder.RenameColumn(
                name: "GenerationWords",
                table: "SourceTexts",
                newName: "Text");
        }
    }
}
