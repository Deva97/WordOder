using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WorkOrder.Migrations
{
    public partial class firstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "Works",
                columns: table => new
                {
                    WorkOrderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InterventionTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Works", x => x.WorkOrderId);
                });

            migrationBuilder.CreateTable(
                name: "WorkBoards",
                columns: table => new
                {
                    JobId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TechnicianId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    WorkId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    IsWorkDone = table.Column<bool>(type: "bit", nullable: false),
                    IsWorkOrderActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkBoards", x => x.JobId);
                    table.ForeignKey(
                        name: "FK_WorkBoards_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WorkBoards_Works_WorkId",
                        column: x => x.WorkId,
                        principalTable: "Works",
                        principalColumn: "WorkOrderId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WorkBoards_TechnicianId",
                table: "WorkBoards",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkBoards_WorkId",
                table: "WorkBoards",
                column: "WorkId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkBoards");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Works");
        }
    }
}
