using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RestServer.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locataires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Password = table.Column<byte[]>(type: "varbinary(max)", maxLength: 50, nullable: false),
                    Actif = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locataires", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Taches",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    DatteFin = table.Column<DateTime>(nullable: false),
                    Active = table.Column<bool>(nullable: false),
                    LocataireId = table.Column<int>(nullable: false),
                    Cycle = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Taches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Taches_Locataires_LocataireId",
                        column: x => x.LocataireId,
                        principalTable: "Locataires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LiaisonTachesLocataires",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocataireId = table.Column<int>(nullable: false),
                    TacheId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiaisonTachesLocataires", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LiaisonTachesLocataires_Locataires_LocataireId",
                        column: x => x.LocataireId,
                        principalTable: "Locataires",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LiaisonTachesLocataires_Taches_TacheId",
                        column: x => x.TacheId,
                        principalTable: "Taches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonTachesLocataires_LocataireId",
                table: "LiaisonTachesLocataires",
                column: "LocataireId");

            migrationBuilder.CreateIndex(
                name: "IX_LiaisonTachesLocataires_TacheId",
                table: "LiaisonTachesLocataires",
                column: "TacheId");

            migrationBuilder.CreateIndex(
                name: "IX_Taches_LocataireId",
                table: "Taches",
                column: "LocataireId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LiaisonTachesLocataires");

            migrationBuilder.DropTable(
                name: "Taches");

            migrationBuilder.DropTable(
                name: "Locataires");
        }
    }
}
