using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class seedTest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PROFILE",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[] { 1, "Adm" });

            migrationBuilder.InsertData(
                table: "PROFILE",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[] { 2, "User" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PROFILE",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PROFILE",
                keyColumn: "ID",
                keyValue: 2);
        }
    }
}
