using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class intitialMigration6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RiskId",
                table: "Controls",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Risks_CategoryId",
                table: "Risks",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_RiskHistories_RiskId",
                table: "RiskHistories",
                column: "RiskId");

            migrationBuilder.CreateIndex(
                name: "IX_Controls_RiskId",
                table: "Controls",
                column: "RiskId");

            migrationBuilder.AddForeignKey(
                name: "FK_Controls_Risks_RiskId",
                table: "Controls",
                column: "RiskId",
                principalTable: "Risks",
                principalColumn: "RiskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RiskHistories_Risks_RiskId",
                table: "RiskHistories",
                column: "RiskId",
                principalTable: "Risks",
                principalColumn: "RiskId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Risks_Categories_CategoryId",
                table: "Risks",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Controls_Risks_RiskId",
                table: "Controls");

            migrationBuilder.DropForeignKey(
                name: "FK_RiskHistories_Risks_RiskId",
                table: "RiskHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_Risks_Categories_CategoryId",
                table: "Risks");

            migrationBuilder.DropIndex(
                name: "IX_Risks_CategoryId",
                table: "Risks");

            migrationBuilder.DropIndex(
                name: "IX_RiskHistories_RiskId",
                table: "RiskHistories");

            migrationBuilder.DropIndex(
                name: "IX_Controls_RiskId",
                table: "Controls");

            migrationBuilder.DropColumn(
                name: "RiskId",
                table: "Controls");

            migrationBuilder.DropColumn(
                name: "RiskId",
                table: "Categories");
        }
    }
}
