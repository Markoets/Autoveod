using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Autoveod.Migrations
{
    public partial class Sisesaine : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Veod",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Algus = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ots = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aeg = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Autonr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JuhtEesnimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JuhtPerenimi = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valmis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veod", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Veod");
        }
    }
}
