using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegaLedProje.Data.Migrations
{
    /// <inheritdoc />
    public partial class denemev2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserType" },
                values: new object[] { new DateTime(2023, 8, 12, 13, 12, 5, 152, DateTimeKind.Local).AddTicks(315), 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UserType" },
                values: new object[] { new DateTime(2023, 8, 11, 15, 47, 24, 524, DateTimeKind.Local).AddTicks(1688), 2 });
        }
    }
}
