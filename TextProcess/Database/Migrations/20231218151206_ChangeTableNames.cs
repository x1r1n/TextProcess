using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextProcess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeTableNames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_SourceTextId",
                table: "GeneratedSentences");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SourceTexts",
                table: "SourceTexts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_GeneratedSentences",
                table: "GeneratedSentences");

            migrationBuilder.RenameTable(
                name: "SourceTexts",
                newName: "SourceText");

            migrationBuilder.RenameTable(
                name: "GeneratedSentences",
                newName: "SyntheticPhrase");

            migrationBuilder.RenameIndex(
                name: "IX_GeneratedSentences_SourceTextId",
                table: "SyntheticPhrase",
                newName: "IX_SyntheticPhrase_SourceTextId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SourceText",
                table: "SourceText",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SyntheticPhrase",
                table: "SyntheticPhrase",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SyntheticPhrase_SourceText_SourceTextId",
                table: "SyntheticPhrase",
                column: "SourceTextId",
                principalTable: "SourceText",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SyntheticPhrase_SourceText_SourceTextId",
                table: "SyntheticPhrase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SyntheticPhrase",
                table: "SyntheticPhrase");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SourceText",
                table: "SourceText");

            migrationBuilder.RenameTable(
                name: "SyntheticPhrase",
                newName: "GeneratedSentences");

            migrationBuilder.RenameTable(
                name: "SourceText",
                newName: "SourceTexts");

            migrationBuilder.RenameIndex(
                name: "IX_SyntheticPhrase_SourceTextId",
                table: "GeneratedSentences",
                newName: "IX_GeneratedSentences_SourceTextId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_GeneratedSentences",
                table: "GeneratedSentences",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SourceTexts",
                table: "SourceTexts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneratedSentences_SourceTexts_SourceTextId",
                table: "GeneratedSentences",
                column: "SourceTextId",
                principalTable: "SourceTexts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
