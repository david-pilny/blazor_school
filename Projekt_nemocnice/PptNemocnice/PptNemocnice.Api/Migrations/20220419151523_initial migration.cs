using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vybaveni",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    BoughtDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastRevisionDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    PriceCzk = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vybaveni", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vybaveni");
        }
    }
}
