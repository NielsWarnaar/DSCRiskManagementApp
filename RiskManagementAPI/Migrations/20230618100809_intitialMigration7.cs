using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class intitialMigration7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NormId",
                table: "Risks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskId",
                table: "Norms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "NormRisk",
                columns: table => new
                {
                    NormRiskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NormId = table.Column<int>(type: "int", nullable: false),
                    RiskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NormRisk", x => x.NormRiskId);
                    table.ForeignKey(
                        name: "FK_NormRisk_Norms_NormId",
                        column: x => x.NormId,
                        principalTable: "Norms",
                        principalColumn: "NormId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NormRisk_Risks_RiskId",
                        column: x => x.RiskId,
                        principalTable: "Risks",
                        principalColumn: "RiskId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NormRisk_NormId",
                table: "NormRisk",
                column: "NormId");

            migrationBuilder.CreateIndex(
                name: "IX_NormRisk_RiskId",
                table: "NormRisk",
                column: "RiskId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NormRisk");

            migrationBuilder.DropColumn(
                name: "NormId",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "RiskId",
                table: "Norms");
        }
    }
}
