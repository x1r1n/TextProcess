using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextProcess.Migrations
{
    /// <inheritdoc />
    public partial class ChangeColumnNameInSyntheticPhrase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Sentence",
                table: "GeneratedSentences",
                newName: "Phrase");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Phrase",
                table: "GeneratedSentences",
                newName: "Sentence");
        }
    }
}
