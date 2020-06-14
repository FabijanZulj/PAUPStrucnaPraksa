using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StrucnaPraksa.Migrations
{
    public partial class osnovniPodaci : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OsnovniPodaci",
                columns: table => new
                {
                    IdUsera = table.Column<string>(nullable: true),
                    Termin = table.Column<DateTime>(nullable: false),
                    Poduzece = table.Column<string>(nullable: true),
                    NazivMentora = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OsnovniPodaci");
        }
    }
}
