using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextProcess.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_SourceTextsId",
                table: "GeneratedSentences");

            migrationBuilder.RenameColumn(
                name: "SourceTextsId",
                table: "GeneratedSentences",
                newName: "TextTitleId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneratedSentences_SourceTextsId",
                table: "GeneratedSentences",
                newName: "IX_GeneratedSentences_TextTitleId");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "SourceTexts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_TextTitleId",
                table: "GeneratedSentences",
                column: "TextTitleId",
                principalTable: "SourceTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_TextTitleId",
                table: "GeneratedSentences");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "SourceTexts");

            migrationBuilder.RenameColumn(
                name: "TextTitleId",
                table: "GeneratedSentences",
                newName: "SourceTextsId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneratedSentences_TextTitleId",
                table: "GeneratedSentences",
                newName: "IX_GeneratedSentences_SourceTextsId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_SourceTextsId",
                table: "GeneratedSentences",
                column: "SourceTextsId",
                principalTable: "SourceTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
