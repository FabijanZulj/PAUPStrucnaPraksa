using Microsoft.EntityFrameworkCore.Migrations;

namespace StrucnaPraksa.Migrations
{
    public partial class addedImePrezimeToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ime",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Prezime",
                table: "Users",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Ime", "Prezime" },
                values: new object[] { "Fabijan", "Zulj" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ime",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Prezime",
                table: "Users");
        }
    }
}
