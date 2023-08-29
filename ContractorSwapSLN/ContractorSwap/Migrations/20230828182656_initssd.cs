using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContractorSwap.Migrations
{
    /// <inheritdoc />
    public partial class initssd : Migration
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
                    Carpentery = table.Column<bool>(type: "bit", nullable: false),
                    Plumbing = table.Column<bool>(type: "bit", nullable: false),
                    General = table.Column<bool>(type: "bit", nullable: false),
                    Electrical = table.Column<bool>(type: "bit", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                    CompletionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Zip = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Carpentery = table.Column<bool>(type: "bit", nullable: false),
                    Plumbing = table.Column<bool>(type: "bit", nullable: false),
                    General = table.Column<bool>(type: "bit", nullable: false),
                    Electrical = table.Column<bool>(type: "bit", nullable: false),
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
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobListingId = table.Column<int>(type: "int", nullable: false),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_Jobs_JobListingId",
                        column: x => x.JobListingId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Applications_Jobs_JobListingModelId",
                        column: x => x.JobListingModelId,
                        principalTable: "Jobs",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Contractors",
                columns: new[] { "Id", "Address", "Carpentery", "City", "Electrical", "Email", "General", "Name", "Password", "Phone", "Plumbing", "State", "UserName", "Zip" },
                values: new object[,]
                {
                    { 1, "baluga", true, "Columbus", false, "email", false, "John Deere", "deerebutstillgoated", "5555555555", true, "Ohio", "johndeere123", "55555" },
                    { 2, "baluga", false, "Columbus", true, "email", true, "Francis Charlery", "francis456", "5555555555", false, "Ohio", "frantheman", "55555" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Address", "Carpentery", "City", "CompletionDate", "ContractorId", "Date", "Description", "Electrical", "General", "Name", "Plumbing", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "baluga", false, "Columbus", new DateTime(2023, 9, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2019, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceiling fan installation: Master Bedroom", false, true, "Test Job", false, "Ohio", "55555" },
                    { 2, "baluga", false, "Columbus", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install a hot tub for a Chihuaha", true, true, "Secondary Job", false, "Ohio", "55555" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Bid", "ContractorId", "Date", "JobListingId", "JobListingModelId", "accepted" },
                values: new object[,]
                {
                    { 1, 750.0, 2, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, false },
                    { 2, 5800.0, 1, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, false }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Applications_ContractorId",
                table: "Applications",
                column: "ContractorId");

            migrationBuilder.CreateIndex(
                name: "IX_Applications_JobListingId",
                table: "Applications",
                column: "JobListingId");

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
