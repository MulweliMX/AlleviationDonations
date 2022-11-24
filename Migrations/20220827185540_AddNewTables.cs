using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterAlleviationFoundation.Migrations
{
    public partial class AddNewTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MonetaryDonations");

            migrationBuilder.CreateTable(
                name: "MoneyDonations",
                columns: table => new
                {
                    MonetaryDonationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoneyDonations", x => x.MonetaryDonationId);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoneyDonations");

            migrationBuilder.CreateTable(
                name: "MonetaryDonations",
                columns: table => new
                {
                    MonetaryDonationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MonetaryDonations", x => x.MonetaryDonationId);
                });

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 27, 20, 52, 33, 732, DateTimeKind.Local).AddTicks(675));

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 27, 20, 52, 33, 732, DateTimeKind.Local).AddTicks(719));
        }
    }
}
