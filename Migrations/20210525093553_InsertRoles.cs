using Microsoft.EntityFrameworkCore.Migrations;

namespace FunTogether.Migrations
{
    public partial class InsertRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d6b2bc72-cb69-4efa-ae9e-23fe9996a661", "8524a8fd-fce6-48e0-b3ea-71f1265e6926", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e0b25638-8537-4cf9-8068-f0ec040178c6", "0fbc8440-fc5f-45ff-84e7-a3ba4d4b995e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "d6b2bc72-cb69-4efa-ae9e-23fe9996a661");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e0b25638-8537-4cf9-8068-f0ec040178c6");
        }
    }
}
