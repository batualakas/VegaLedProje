using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VegaLedProje.Data.Migrations
{
    /// <inheritdoc />
    public partial class v123546 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 9, 15, 23, 13, 0, 595, DateTimeKind.Local).AddTicks(5817), new DateTime(2023, 9, 15, 23, 13, 0, 595, DateTimeKind.Local).AddTicks(5830) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "ModifiedDate" },
                values: new object[] { new DateTime(2023, 8, 12, 13, 12, 5, 152, DateTimeKind.Local).AddTicks(315), null });
        }
    }
}
