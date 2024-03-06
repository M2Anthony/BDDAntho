using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Exercice04.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dragons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dragons", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Dragons",
                columns: new[] { "Id", "Age", "Description", "Nom" },
                values: new object[] { 1, 6, "Le favori des dragons", "Drogon" });

            migrationBuilder.InsertData(
                table: "Dragons",
                columns: new[] { "Id", "Age", "Description", "Nom" },
                values: new object[] { 2, 6, "Le dragon mort vivant", "Viserion" });

            migrationBuilder.InsertData(
                table: "Dragons",
                columns: new[] { "Id", "Age", "Description", "Nom" },
                values: new object[] { 3, 6, "Le premier dragon a mourir", "Rhaegal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dragons");
        }
    }
}
