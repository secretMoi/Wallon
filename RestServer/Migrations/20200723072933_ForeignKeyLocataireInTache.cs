using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestServer.Migrations
{
    public partial class ForeignKeyLocataireInTache : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Taches_Locataires_LocataireId",
                table: "Taches");

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Taches",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(256)",
                oldMaxLength: 256);

            migrationBuilder.AlterColumn<int>(
                name: "LocataireId",
                table: "Taches",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "Locataires",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Locataires",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldMaxLength: 50);

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

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Taches",
                type: "varchar(256)",
                maxLength: 256,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocataireId",
                table: "Taches",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "Password",
                table: "Locataires",
                type: "varbinary(max)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nom",
                table: "Locataires",
                type: "varchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
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
