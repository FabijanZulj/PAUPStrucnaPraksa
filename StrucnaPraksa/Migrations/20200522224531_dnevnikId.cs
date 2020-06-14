using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StrucnaPraksa.Migrations
{
    public partial class dnevnikId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "IdPodataka",
                table: "OsnovniPodaci",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_OsnovniPodaci",
                table: "OsnovniPodaci",
                column: "IdPodataka");

            migrationBuilder.CreateTable(
                name: "Ankete",
                columns: table => new
                {
                    IdAnkete = table.Column<string>(nullable: false),
                    IdUsera = table.Column<string>(nullable: true),
                    Godina = table.Column<DateTime>(nullable: false),
                    Prvo = table.Column<string>(nullable: true),
                    Drugo = table.Column<string>(nullable: true),
                    Trece = table.Column<string>(nullable: true),
                    Cetvrto = table.Column<string>(nullable: true),
                    Peto = table.Column<string>(nullable: true),
                    Sesto = table.Column<string>(nullable: true),
                    Sedmo = table.Column<string>(nullable: true),
                    Osmo = table.Column<string>(nullable: true),
                    Deveto = table.Column<string>(nullable: true),
                    Deseto = table.Column<string>(nullable: true),
                    Jedanaesto = table.Column<string>(nullable: true),
                    Dvanaesto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ankete", x => x.IdAnkete);
                });

            migrationBuilder.CreateTable(
                name: "Dnevnici",
                columns: table => new
                {
                    IdDnevnika = table.Column<string>(nullable: false),
                    IdUsera = table.Column<string>(nullable: true),
                    FileUrl = table.Column<string>(nullable: true),
                    Godina = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dnevnici", x => x.IdDnevnika);
                });

            migrationBuilder.CreateTable(
                name: "Izvjesca",
                columns: table => new
                {
                    IdIzvjesca = table.Column<string>(nullable: false),
                    IdUsera = table.Column<string>(nullable: true),
                    FileUrl = table.Column<string>(nullable: true),
                    Godina = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Izvjesca", x => x.IdIzvjesca);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ankete");

            migrationBuilder.DropTable(
                name: "Dnevnici");

            migrationBuilder.DropTable(
                name: "Izvjesca");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OsnovniPodaci",
                table: "OsnovniPodaci");

            migrationBuilder.AlterColumn<string>(
                name: "IdPodataka",
                table: "OsnovniPodaci",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
