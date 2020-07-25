using Microsoft.EntityFrameworkCore.Migrations;

namespace RestServer.Migrations
{
    public partial class AddNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Locataires_LocataireId",
                table: "Taches");

            migrationBuilder.AlterColumn<int>(
                name: "LocataireId",
                table: "Taches",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Locataires_LocataireId",
                table: "Taches",
                column: "LocataireId",
                principalTable: "Locataires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Locataires_LocataireId",
                table: "Taches");

            migrationBuilder.AlterColumn<int>(
                name: "LocataireId",
                table: "Taches",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Taches_Locataires_LocataireId",
                table: "Taches",
                column: "LocataireId",
                principalTable: "Locataires",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
