using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataAnalysisAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SalarySpendDetailsDailies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InsertedTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    SmallestSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    DepartmentWithSmallestSalary = table.Column<string>(type: "text", nullable: false),
                    LargestSalary = table.Column<decimal>(type: "numeric", nullable: false),
                    DepartmentWithLargestSalary = table.Column<string>(type: "text", nullable: false),
                    TotalSpend = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalarySpendDetailsDailies", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalarySpendDetailsDailies");
        }
    }
}
