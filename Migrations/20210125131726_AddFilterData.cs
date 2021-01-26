using Microsoft.EntityFrameworkCore.Migrations;

namespace FunTogether.Migrations
{
    public partial class AddFilterData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Filters",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Activities",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Filters",
                columns: new[] { "Id", "Category", "Value" },
                values: new object[,]
                {
                    { 1, "AgeGroup", "18-23" },
                    { 2, "AgeGroup", "24-29" },
                    { 3, "AgeGroup", "30-39" },
                    { 4, "AgeGroup", "40-49" },
                    { 5, "AgeGroup", "50+" },
                    { 6, "Gender", "Female" },
                    { 7, "Gender", "Male" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Filters",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Filters",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Filters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Filters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Filters",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Filters",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Filters",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Activities");

            migrationBuilder.AlterColumn<string>(
                name: "Category",
                table: "Filters",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
