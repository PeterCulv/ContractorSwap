using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContractorSwap.Migrations
{
    /// <inheritdoc />
    public partial class hello : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Bid", "JobListingId", "JobListingModelId", "SeekerId" },
                values: new object[,]
                {
                    { 1, 750.0, 1, null, 2 },
                    { 2, 5800.0, 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "AcceptedId", "ContractorModelId", "Date", "Description", "Location", "Name", "PosterId" },
                values: new object[,]
                {
                    { 1, 0, null, new DateTime(2019, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceiling fan installation: Master Bedroom", "666 Elm Street, Aurora, IL", "Test Job", 1 },
                    { 2, 0, null, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install a hot tub for a Chihuaha", "1111 Hampton Hills Ct., Hamptons, CT", "Secondary Job", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Applications",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
