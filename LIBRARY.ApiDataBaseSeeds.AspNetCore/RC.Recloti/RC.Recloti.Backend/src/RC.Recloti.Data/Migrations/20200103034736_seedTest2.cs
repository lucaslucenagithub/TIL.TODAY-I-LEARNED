using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class seedTest2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PROFILE",
                columns: new[] { "ID", "DESCRIPTION" },
                values: new object[] { 3, "Moderator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PROFILE",
                keyColumn: "ID",
                keyValue: 3);
        }
    }
}
