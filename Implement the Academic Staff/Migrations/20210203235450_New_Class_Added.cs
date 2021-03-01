using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PositionDatabase.Migrations
{
    public partial class New_Class_Added : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Position",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "SalaryComponent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<int>(nullable: false),
                    Value = table.Column<decimal>(nullable: false),
                    PersonId = table.Column<Guid>(nullable: false),
                    PersonId1 = table.Column<int>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    PositionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryComponent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryComponent_Person_PersonId1",
                        column: x => x.PersonId1,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SalaryComponent_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalaryScale",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StartDate = table.Column<DateTime>(nullable: false),
                    EndDate = table.Column<DateTime>(nullable: false),
                    PositionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryScale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryScale_Position_PositionId",
                        column: x => x.PositionId,
                        principalTable: "Position",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SalaryStep",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SalaryScaleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SalaryStep", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SalaryStep_SalaryScale_SalaryScaleId",
                        column: x => x.SalaryScaleId,
                        principalTable: "SalaryScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SalaryComponent_PersonId1",
                table: "SalaryComponent",
                column: "PersonId1");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryComponent_PositionId",
                table: "SalaryComponent",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryScale_PositionId",
                table: "SalaryScale",
                column: "PositionId");

            migrationBuilder.CreateIndex(
                name: "IX_SalaryStep_SalaryScaleId",
                table: "SalaryStep",
                column: "SalaryScaleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SalaryComponent");

            migrationBuilder.DropTable(
                name: "SalaryStep");

            migrationBuilder.DropTable(
                name: "SalaryScale");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Position");
        }
    }
}
