using Microsoft.EntityFrameworkCore.Migrations;

namespace RestServer.Migrations
{
    public partial class AjoutColonneDescriptionTache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Taches",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Taches");
        }
    }
}
