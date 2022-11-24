using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterAlleviationFoundation.Migrations
{
    public partial class AddGoodDonations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GoodDonations",
                columns: table => new
                {
                    GoodDonationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfItems = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CatergoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoodDonations", x => x.GoodDonationId);
                    table.ForeignKey(
                        name: "FK_GoodDonations_Catergories_CatergoryId",
                        column: x => x.CatergoryId,
                        principalTable: "Catergories",
                        principalColumn: "CatergoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 27, 21, 17, 39, 605, DateTimeKind.Local).AddTicks(4229));

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 27, 21, 17, 39, 605, DateTimeKind.Local).AddTicks(4252));

            migrationBuilder.CreateIndex(
                name: "IX_GoodDonations_CatergoryId",
                table: "GoodDonations",
                column: "CatergoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GoodDonations");

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 27, 20, 55, 39, 564, DateTimeKind.Local).AddTicks(3847));

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 27, 20, 55, 39, 564, DateTimeKind.Local).AddTicks(3878));
        }
    }
}
