using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StrucnaPraksa.Migrations
{
    public partial class osnovniPodaciIdPodataka : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Termin",
                table: "OsnovniPodaci",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "IdPodataka",
                table: "OsnovniPodaci",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdPodataka",
                table: "OsnovniPodaci");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Termin",
                table: "OsnovniPodaci",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
