using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class initialUkony : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Ukon",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Kod",
                table: "Ukon",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "PracovnikId",
                table: "Ukon",
                type: "TEXT",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Pracvnik",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    JobTitle = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pracvnik", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ukon_PracovnikId",
                table: "Ukon",
                column: "PracovnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Ukon_Pracvnik_PracovnikId",
                table: "Ukon",
                column: "PracovnikId",
                principalTable: "Pracvnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ukon_Pracvnik_PracovnikId",
                table: "Ukon");

            migrationBuilder.DropTable(
                name: "Pracvnik");

            migrationBuilder.DropIndex(
                name: "IX_Ukon_PracovnikId",
                table: "Ukon");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Ukon");

            migrationBuilder.DropColumn(
                name: "Kod",
                table: "Ukon");

            migrationBuilder.DropColumn(
                name: "PracovnikId",
                table: "Ukon");
        }
    }
}
