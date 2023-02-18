using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousingSociety.Data.Migrations
{
    public partial class InitialCreatetransa : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flats",
                columns: table => new
                {
                    FlatNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlatName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FlatOwner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AAdhar = table.Column<long>(type: "bigint", nullable: true),
                    Contact = table.Column<long>(type: "bigint", nullable: false),
                    Wing = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flats", x => x.FlatNo);
                });

            migrationBuilder.CreateTable(
                name: "Maintenances",
                columns: table => new
                {
                    MaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceType = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenances", x => x.MaintenanceId);
                });

            migrationBuilder.CreateTable(
                name: "Transactions",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TransactionAmount = table.Column<int>(type: "int", nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaintenanceId = table.Column<int>(type: "int", nullable: false),
                    FlatNo = table.Column<int>(type: "int", nullable: false)
                 
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transactions_Flats_FlatNo1",
                        column: x => x.FlatNo,
                        principalTable: "Flats",
                        principalColumn: "FlatNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Transactions_Maintenances_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenances",
                        principalColumn: "MaintenanceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_FlatNo1",
                table: "Transactions",
                column: "FlatNo1");

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_MaintenanceId",
                table: "Transactions",
                column: "MaintenanceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transactions");

            migrationBuilder.DropTable(
                name: "Flats");

            migrationBuilder.DropTable(
                name: "Maintenances");
        }
    }
}
