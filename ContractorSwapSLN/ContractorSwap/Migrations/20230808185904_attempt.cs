using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ContractorSwap.Migrations
{
    /// <inheritdoc />
    public partial class attempt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PosterId",
                table: "Jobs",
                newName: "ContractorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContractorId",
                table: "Jobs",
                newName: "PosterId");
        }
    }
}
