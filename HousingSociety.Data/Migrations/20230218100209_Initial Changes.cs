using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousingSociety.Data.Migrations
{
    public partial class InitialChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Flats_FlatNo1",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "FlatNo",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "FlatNo1",
                table: "Transactions",
                newName: "FlatId");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FlatNo1",
                table: "Transactions",
                newName: "IX_Transactions_FlatId");

            migrationBuilder.RenameColumn(
                name: "FlatNo",
                table: "Flats",
                newName: "FlatId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Flats_FlatId",
                table: "Transactions",
                column: "FlatId",
                principalTable: "Flats",
                principalColumn: "FlatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_Flats_FlatId",
                table: "Transactions");

            migrationBuilder.RenameColumn(
                name: "FlatId",
                table: "Transactions",
                newName: "FlatNo1");

            migrationBuilder.RenameIndex(
                name: "IX_Transactions_FlatId",
                table: "Transactions",
                newName: "IX_Transactions_FlatNo1");

            migrationBuilder.RenameColumn(
                name: "FlatId",
                table: "Flats",
                newName: "FlatNo");

            migrationBuilder.AddColumn<int>(
                name: "FlatNo",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_Flats_FlatNo1",
                table: "Transactions",
                column: "FlatNo1",
                principalTable: "Flats",
                principalColumn: "FlatNo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
