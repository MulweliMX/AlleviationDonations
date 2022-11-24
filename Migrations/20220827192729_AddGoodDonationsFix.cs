using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterAlleviationFoundation.Migrations
{
    public partial class AddGoodDonationsFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
