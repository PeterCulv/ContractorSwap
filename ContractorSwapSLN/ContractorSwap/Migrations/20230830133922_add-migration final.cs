using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContractorSwap.Migrations
{
    /// <inheritdoc />
    public partial class addmigrationfinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Bid",
                value: 800.0);

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Bid", "ContractorId", "Date", "JobListingId", "JobListingModelId", "accepted" },
                values: new object[,]
                {
                    { 3, 1200.0, 3, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, false },
                    { 4, 5800.0, 3, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, false },
                    { 5, 850.0, 3, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false },
                    { 6, 3350.0, 1, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, false },
                    { 7, 825.0, 2, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false },
                    { 8, 875.0, 1, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false },
                    { 9, 750.0, 4, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false },
                    { 10, 5800.0, 4, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, false }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.UpdateData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2,
                column: "Bid",
                value: 5800.0);
        }
    }
}
