using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class intitialMigration9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RiskHistories_Risks_RiskId",
                table: "RiskHistories");

            migrationBuilder.DropIndex(
                name: "IX_RiskHistories_RiskId",
                table: "RiskHistories");

            migrationBuilder.DropColumn(
                name: "RiskId",
                table: "Categories");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Risks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Risks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "RiskId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RiskHistories_RiskId",
                table: "RiskHistories",
                column: "RiskId");

            migrationBuilder.AddForeignKey(
                name: "FK_RiskHistories_Risks_RiskId",
                table: "RiskHistories",
                column: "RiskId",
                principalTable: "Risks",
                principalColumn: "RiskId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
