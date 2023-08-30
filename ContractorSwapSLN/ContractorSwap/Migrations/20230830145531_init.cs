using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ContractorSwap.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
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
                columns: new[] { "Id", "Address", "Carpentery", "City", "Electrical", "Email", "General", "Name", "Password", "Phone", "Plumbing", "State", "UserName", "Zip" },
                values: new object[,]
                {
                    { 1, "baluga", true, "Columbus", false, "email", false, "John Deere", "deerebutstillgoated", "5555555555", true, "Ohio", "johndeere123", "55555" },
                    { 2, "baluga", false, "Columbus", true, "email", true, "Francis Charlery", "francis456", "5555555555", false, "Ohio", "frantheman", "55555" },
                    { 3, "8017 Yager Way", false, "Columbus", true, "stonechalmers49@aol.com", false, "Stone Chalmers", "ChalStone1975", "2093541980", true, "Ohio", "StoneyC", "55555" },
                    { 4, "144 Spruce St", true, "Columbus", true, "smittyman12@aol.com", true, "Tim Smith", "tinmansmitty", "8179314754", false, "Ohio", "TimmySmit", "55555" }
                });

            migrationBuilder.InsertData(
                table: "Jobs",
                columns: new[] { "Id", "Address", "Carpentery", "City", "CompletionDate", "ContractorId", "Date", "Description", "Electrical", "General", "Name", "Plumbing", "State", "Zip" },
                values: new object[,]
                {
                    { 1, "baluga", false, "Columbus", new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 8, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ceiling fan installation: Master Bedroom", false, true, "Ceiling Fan Install", false, "Ohio", "55555" },
                    { 2, "baluga", false, "Columbus", new DateTime(2023, 8, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install a hot tub for a Chihuaha", true, true, "Tiny Hot Tub For Dog", false, "Ohio", "55555" },
                    { 3, "809 ", false, "Columbus", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install new shower in master bathroom.", true, false, "Master Bathroom Shower", true, "Ohio", "55555" },
                    { 4, "19 BelAir St", false, "Columbus", new DateTime(2023, 8, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), "Install home sound system throughout the house. I have all the new speakers on site.", true, false, "Install Whole Home Sound System", true, "Ohio", "55555" },
                    { 5, "86 Elm Dr", false, "Columbus", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2023, 6, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "My husband and I recently bought the house and have to rewire the whole house to be up to code.", true, false, "Rewire House", true, "Ohio", "55555" },
                    { 6, "651 Oak St", false, "Columbus", new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2023, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "I need a 24 x 24 shed built so I have a place for my yoga.", false, true, "Build She-Shed", false, "Ohio", "55555" },
                    { 7, "305 Center Ct", true, "Columbus", new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2023, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "I want a 20 x 20 outdoor grill with a bar.", true, true, "Outdoor Grill", false, "Ohio", "55555" }
                });

            migrationBuilder.InsertData(
                table: "Applications",
                columns: new[] { "Id", "Bid", "ContractorId", "Date", "JobListingId", "JobListingModelId", "accepted" },
                values: new object[,]
                {
                    { 1, 750.0, 2, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, false },
                    { 2, 800.0, 3, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, false },
                    { 3, 1200.0, 1, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, null, false },
                    { 4, 5800.0, 3, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 5, null, false },
                    { 5, 850.0, 4, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false },
                    { 6, 3350.0, 1, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, false },
                    { 7, 825.0, 2, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false },
                    { 8, 875.0, 1, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false },
                    { 9, 750.0, 4, new DateTime(2023, 6, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, false },
                    { 10, 5800.0, 4, new DateTime(2023, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, false }
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
