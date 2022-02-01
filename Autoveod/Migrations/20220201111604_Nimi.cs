using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoveod.Migrations
{
    public partial class Nimi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nimi",
                table: "Veod",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nimi",
                table: "Veod");
        }
    }
}
