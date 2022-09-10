using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DesafioLoldesign.API.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rates",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DddOrigin = table.Column<int>(type: "INTEGER", nullable: false),
                    DddDestiny = table.Column<int>(type: "INTEGER", nullable: false),
                    PricePerMinute = table.Column<decimal>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rates", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rates");
        }
    }
}
