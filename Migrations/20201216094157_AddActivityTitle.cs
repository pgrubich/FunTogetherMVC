using Microsoft.EntityFrameworkCore.Migrations;

namespace FunTogether.Migrations
{
    public partial class AddActivityTitle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Activities",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Title",
                table: "Activities");
        }
    }
}
