using Microsoft.EntityFrameworkCore.Migrations;

namespace StrucnaPraksa.Migrations
{
    public partial class anketaAddedKomentari : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DesetoKomentar",
                table: "Ankete",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SedmoKomentar",
                table: "Ankete",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DesetoKomentar",
                table: "Ankete");

            migrationBuilder.DropColumn(
                name: "SedmoKomentar",
                table: "Ankete");
        }
    }
}
