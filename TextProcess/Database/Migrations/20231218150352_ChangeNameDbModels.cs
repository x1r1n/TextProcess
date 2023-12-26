using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextProcess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeNameDbModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_TextId",
                table: "GeneratedSentences");

            migrationBuilder.RenameColumn(
                name: "TextId",
                table: "GeneratedSentences",
                newName: "SourceTextId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneratedSentences_TextId",
                table: "GeneratedSentences",
                newName: "IX_GeneratedSentences_SourceTextId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_SourceTextId",
                table: "GeneratedSentences",
                column: "SourceTextId",
                principalTable: "SourceTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_SourceTextId",
                table: "GeneratedSentences");

            migrationBuilder.RenameColumn(
                name: "SourceTextId",
                table: "GeneratedSentences",
                newName: "TextId");

            migrationBuilder.RenameIndex(
                name: "IX_GeneratedSentences_SourceTextId",
                table: "GeneratedSentences",
                newName: "IX_GeneratedSentences_TextId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_TextId",
                table: "GeneratedSentences",
                column: "TextId",
                principalTable: "SourceTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
