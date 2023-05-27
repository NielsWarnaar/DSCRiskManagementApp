using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RiskManagementAPI.Migrations
{
    /// <inheritdoc />
    public partial class intitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Categorydescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Controls",
                columns: table => new
                {
                    ControlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ControlName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ControlType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Controls", x => x.ControlId);
                });

            migrationBuilder.CreateTable(
                name: "Norms",
                columns: table => new
                {
                    NormId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NormName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NormDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Norms", x => x.NormId);
                });

            migrationBuilder.CreateTable(
                name: "Risks",
                columns: table => new
                {
                    RiskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    ActionType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutstandingActions = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Classification = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdated = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Risks", x => x.RiskId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Controls");

            migrationBuilder.DropTable(
                name: "Norms");

            migrationBuilder.DropTable(
                name: "Risks");
        }
    }
}
