using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TextProcess.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SourceTexts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SourceTexts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneratedSentences",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sentence = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SourceTextsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneratedSentences", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneratedSentences_SourceTexts_SourceTextsId",
                        column: x => x.SourceTextsId,
                        principalTable: "SourceTexts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GeneratedSentences_SourceTextsId",
                table: "GeneratedSentences",
                column: "SourceTextsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneratedSentences");

            migrationBuilder.DropTable(
                name: "SourceTexts");
        }
    }
}
