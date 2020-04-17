using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class attProfiles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PROFILE",
                keyColumn: "ID",
                keyValue: 1,
                column: "DESCRIPTION",
                value: "Administrador");

            migrationBuilder.UpdateData(
                table: "PROFILE",
                keyColumn: "ID",
                keyValue: 2,
                column: "DESCRIPTION",
                value: "Cliente");

            migrationBuilder.UpdateData(
                table: "PROFILE",
                keyColumn: "ID",
                keyValue: 3,
                column: "DESCRIPTION",
                value: "Moderador");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "PROFILE",
                keyColumn: "ID",
                keyValue: 1,
                column: "DESCRIPTION",
                value: "Adm");

            migrationBuilder.UpdateData(
                table: "PROFILE",
                keyColumn: "ID",
                keyValue: 2,
                column: "DESCRIPTION",
                value: "User");

            migrationBuilder.UpdateData(
                table: "PROFILE",
                keyColumn: "ID",
                keyValue: 3,
                column: "DESCRIPTION",
                value: "Moderator");
        }
    }
}
