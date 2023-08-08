using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractorSwap.Migrations
{
    /// <inheritdoc />
    public partial class hieee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Contractors_ContractorModelId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ContractorModelId",
                table: "Jobs");

            migrationBuilder.DropColumn(
                name: "ContractorModelId",
                table: "Jobs");

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ContractorId",
                table: "Jobs",
                column: "ContractorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Contractors_ContractorId",
                table: "Jobs",
                column: "ContractorId",
                principalTable: "Contractors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jobs_Contractors_ContractorId",
                table: "Jobs");

            migrationBuilder.DropIndex(
                name: "IX_Jobs_ContractorId",
                table: "Jobs");

            migrationBuilder.AddColumn<int>(
                name: "ContractorModelId",
                table: "Jobs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 1,
                column: "ContractorModelId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Jobs",
                keyColumn: "Id",
                keyValue: 2,
                column: "ContractorModelId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Jobs_ContractorModelId",
                table: "Jobs",
                column: "ContractorModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jobs_Contractors_ContractorModelId",
                table: "Jobs",
                column: "ContractorModelId",
                principalTable: "Contractors",
                principalColumn: "Id");
        }
    }
}
