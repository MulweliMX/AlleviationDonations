using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterAlleviationFoundation.Migrations
{
    public partial class AddGoodDonationsToAddDonor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Donor",
                table: "GoodDonations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 27, 21, 41, 18, 590, DateTimeKind.Local).AddTicks(4524));

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 27, 21, 41, 18, 590, DateTimeKind.Local).AddTicks(4550));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Donor",
                table: "GoodDonations");

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 27, 21, 27, 28, 875, DateTimeKind.Local).AddTicks(8208));

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 27, 21, 27, 28, 875, DateTimeKind.Local).AddTicks(8240));
        }
    }
}
