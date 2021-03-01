using Microsoft.EntityFrameworkCore.Migrations;

namespace PositionDatabase.Migrations
{
    public partial class mmmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "SalaryComponent");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "SalaryComponent",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
