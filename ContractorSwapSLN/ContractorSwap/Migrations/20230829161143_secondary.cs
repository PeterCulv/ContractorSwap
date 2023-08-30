using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContractorSwap.Migrations
{
    /// <inheritdoc />
    public partial class secondary : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "Id", "Address", "Carpentery", "City", "Electrical", "Email", "General", "Name", "Password", "Phone", "Plumbing", "State", "UserName", "Zip" },
                values: new object[,]
                {
                    { 3, "8017 Yager Way", false, "Columbus", true, "stonechalmers49@aol.com", false, "Stone Chalmers", "ChalStone1975", "2093541980", true, "Ohio", "StoneyC", "55555" },
                    { 4, "144 Spruce St", true, "Columbus", true, "smittyman12@aol.com", true, "Tim Smith", "tinmansmitty", "8179314754", false, "Ohio", "TimmySmit", "55555" }
                });

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Ceiling Fan Install");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Tiny Hot Tub For Dog");

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Address", "Carpentery", "City", "CompletionDate", "ContractorId", "Date", "Description", "Electrical", "General", "Name", "Plumbing", "State", "Zip" },
                values: new object[,]
                {
                    { 6, "651 Oak St", false, "Columbus", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "I need a 24 x 24 shed built so I have a place for my yoga.", false, true, "Build She-Shed", false, "Ohio", "55555" },
                    { 3, "809 ", false, "Columbus", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install new shower in master bathroom.", true, false, "Master Bathroom Shower", true, "Ohio", "55555" },
                    { 4, "19 BelAir St", false, "Columbus", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install home sound system throughout the house. I have all the new speakers on site.", true, false, "Install Whole Home Sound System", true, "Ohio", "55555" },
                    { 5, "86 Elm Dr", false, "Columbus", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "My husband and I recently bought the house and have to rewire the whole house to be up to code.", true, false, "Rewire House", true, "Ohio", "55555" },
                    { 7, "305 Center Ct", true, "Columbus", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "I want a 20 x 20 outdoor grill with a bar.", true, true, "Outdoor Grill", false, "Ohio", "55555" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contractors",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Test Job");

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Secondary Job");
        }
    }
}
