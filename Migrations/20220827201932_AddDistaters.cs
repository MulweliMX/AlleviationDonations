using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DisasterAlleviationFoundation.Migrations
{
    public partial class AddDistaters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Disasters",
                columns: table => new
                {
                    DisasterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    End = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AidTypes = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Disasters", x => x.DisasterId);
                });

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2022, 8, 27, 22, 19, 31, 699, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "Catergories",
                keyColumn: "CatergoryId",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2022, 8, 27, 22, 19, 31, 699, DateTimeKind.Local).AddTicks(6213));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Disasters");

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
    }
}
