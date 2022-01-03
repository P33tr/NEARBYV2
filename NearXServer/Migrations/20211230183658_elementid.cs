using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NearXServer.Migrations
{
    public partial class elementid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ElementId",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ElementId",
                table: "Reviews");
        }
    }
}
