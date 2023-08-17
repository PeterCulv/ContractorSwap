using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContractorSwap.Migrations
{
    /// <inheritdoc />
    public partial class testing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contractors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Specialties = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contractors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ContractorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Jobs_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Applications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Bid = table.Column<double>(type: "float", nullable: false),
                    accepted = table.Column<bool>(type: "bit", nullable: false),
                    ContractorId = table.Column<int>(type: "int", nullable: false),
                    JobListingModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Applications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Applications_Contractors_ContractorId",
                        column: x => x.ContractorId,
                        principalTable: "Contractors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Applications_Jobs_JobListingModelId",
                        column: x => x.JobListingModelId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "Id", "Location", "Name", "Password", "Specialties", "UserName" },
                values: new object[,]
                {
                    { 1, "Grand Detour, Illinois", "John Deere", "deerebutstillgoated", "Landscaping", "johndeere123" },
                    { 2, "Hartford, Connecticut", "Francis Charlery", "francis456", "Carpenrty", "frantheman" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Bid", "ContractorId", "JobListingModelId", "accepted" },
                values: new object[,]
                {
                    { 1, 750.0, 2, null, false },
                    { 2, 5800.0, 1, null, false }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "ContractorId", "Date", "Description", "Location", "Name" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2019, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceiling fan installation: Master Bedroom", "666 Elm Street, Aurora, IL", "Test Job" },
                    { 2, 2, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install a hot tub for a Chihuaha", "1111 Hampton Hills Ct., Hamptons, CT", "Secondary Job" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ContractorId",
                table: "Applications",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobListingModelId",
                table: "Applications",
                column: "JobListingModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ContractorId",
                table: "Jobs",
                column: "ContractorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Applications");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "Contractors");
        }
    }
}
