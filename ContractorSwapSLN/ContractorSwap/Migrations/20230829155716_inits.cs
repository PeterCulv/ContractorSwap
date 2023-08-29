﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractorSwap.Migrations
{
    /// <inheritdoc />
    public partial class inits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobListingId",
                table: "Applications");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobListingId",
                table: "Applications",
                column: "JobListingId",
                principalTable: "Jobs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Jobs_JobListingId",
                table: "Applications");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Jobs_JobListingId",
                table: "Applications",
                column: "JobListingId",
                principalTable: "Jobs",
                principalColumn: "Id");
        }
    }
}
