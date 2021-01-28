using Microsoft.EntityFrameworkCore.Migrations;

namespace PositionDatabase.Migrations
{
    public partial class AnotherChangeInPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ContractType",
                table: "Positions",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ContractType",
                table: "Positions",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));
        }
    }
}
