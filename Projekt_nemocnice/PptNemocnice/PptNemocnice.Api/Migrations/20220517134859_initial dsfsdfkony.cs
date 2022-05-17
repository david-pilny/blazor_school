using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class initialdsfsdfkony : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ukon_Pracvnik_PracovnikId",
                table: "Ukon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pracvnik",
                table: "Pracvnik");

            migrationBuilder.RenameTable(
                name: "Pracvnik",
                newName: "Pracovnik");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pracovnik",
                table: "Pracovnik",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ukon_Pracovnik_PracovnikId",
                table: "Ukon",
                column: "PracovnikId",
                principalTable: "Pracovnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ukon_Pracovnik_PracovnikId",
                table: "Ukon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pracovnik",
                table: "Pracovnik");

            migrationBuilder.RenameTable(
                name: "Pracovnik",
                newName: "Pracvnik");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pracvnik",
                table: "Pracvnik",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Ukon_Pracvnik_PracovnikId",
                table: "Ukon",
                column: "PracovnikId",
                principalTable: "Pracvnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
