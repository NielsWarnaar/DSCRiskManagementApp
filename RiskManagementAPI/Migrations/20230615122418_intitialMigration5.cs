using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class intitialMigration5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ImpactValueControlled",
                table: "Risks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpactValueInherent",
                table: "Risks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProbabilityValueControlled",
                table: "Risks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProbabilityValueInherent",
                table: "Risks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskValueControlled",
                table: "Risks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskValueInherent",
                table: "Risks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpactValueControlled",
                table: "RiskHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ImpactValueInherent",
                table: "RiskHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProbabilityValueControlled",
                table: "RiskHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProbabilityValueInherent",
                table: "RiskHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskValueControlled",
                table: "RiskHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RiskValueInherent",
                table: "RiskHistories",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImpactValueControlled",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "ImpactValueInherent",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "ProbabilityValueControlled",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "ProbabilityValueInherent",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "RiskValueControlled",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "RiskValueInherent",
                table: "Risks");

            migrationBuilder.DropColumn(
                name: "ImpactValueControlled",
                table: "RiskHistories");

            migrationBuilder.DropColumn(
                name: "ImpactValueInherent",
                table: "RiskHistories");

            migrationBuilder.DropColumn(
                name: "ProbabilityValueControlled",
                table: "RiskHistories");

            migrationBuilder.DropColumn(
                name: "ProbabilityValueInherent",
                table: "RiskHistories");

            migrationBuilder.DropColumn(
                name: "RiskValueControlled",
                table: "RiskHistories");

            migrationBuilder.DropColumn(
                name: "RiskValueInherent",
                table: "RiskHistories");
        }
    }
}
