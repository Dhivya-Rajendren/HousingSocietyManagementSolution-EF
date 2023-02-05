using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HousingSociety.Data.Migrations
{
    public partial class AddaStatuscolumninFlat1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "Flats",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "Flats");
        }
    }
}
