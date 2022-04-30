using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PptNemocnice.Api.Migrations
{
    public partial class Tabulkarevize1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vybaveni",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    PriceCzk = table.Column<double>(type: "REAL", nullable: false),
                    BoughtDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vybaveni", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Revize",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    DateTime = table.Column<DateTime>(type: "TEXT", nullable: false),
                    VybaveniId = table.Column<Guid>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Revize", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Revize_Vybaveni_VybaveniId",
                        column: x => x.VybaveniId,
                        principalTable: "Vybaveni",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Vybaveni",
                columns: new[] { "Id", "BoughtDate", "Name", "PriceCzk" },
                values: new object[] { new Guid("1d33d29e-e9f6-439d-ab3a-6aa4c49da9d5"), new DateTime(2015, 3, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "CT Scanner", 1324653.0 });

            migrationBuilder.InsertData(
                table: "Vybaveni",
                columns: new[] { "Id", "BoughtDate", "Name", "PriceCzk" },
                values: new object[] { new Guid("516cd84c-74be-460d-bd3b-5499afabef23"), new DateTime(2017, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikroskop", 24246.0 });

            migrationBuilder.InsertData(
                table: "Vybaveni",
                columns: new[] { "Id", "BoughtDate", "Name", "PriceCzk" },
                values: new object[] { new Guid("ccc693cf-3fc5-42b3-962e-fd1ba1a3091d"), new DateTime(2012, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rentgen", 783278.0 });

            migrationBuilder.InsertData(
                table: "Revize",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniId" },
                values: new object[] { new Guid("8334e45a-157f-4044-a675-53e6d977290d"), new DateTime(2021, 1, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mikroskop", new Guid("1d33d29e-e9f6-439d-ab3a-6aa4c49da9d5") });

            migrationBuilder.InsertData(
                table: "Revize",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniId" },
                values: new object[] { new Guid("839da36b-86a6-475a-a157-5945ec20fe69"), new DateTime(2020, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rentgen", new Guid("ccc693cf-3fc5-42b3-962e-fd1ba1a3091d") });

            migrationBuilder.InsertData(
                table: "Revize",
                columns: new[] { "Id", "DateTime", "Name", "VybaveniId" },
                values: new object[] { new Guid("f8bd0762-5f23-4f80-bcd8-5aef1d674c49"), new DateTime(2019, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "CT Scanner", new Guid("1d33d29e-e9f6-439d-ab3a-6aa4c49da9d5") });

            migrationBuilder.CreateIndex(
                name: "IX_Revize_VybaveniId",
                table: "Revize",
                column: "VybaveniId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Revize");

            migrationBuilder.DropTable(
                name: "Vybaveni");
        }
    }
}
