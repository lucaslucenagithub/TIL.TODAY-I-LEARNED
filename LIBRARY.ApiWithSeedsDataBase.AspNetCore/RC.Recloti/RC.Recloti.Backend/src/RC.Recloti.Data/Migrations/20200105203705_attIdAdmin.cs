using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class attIdAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "ID",
                keyValue: 27816234);

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "ID", "ACTIVE", "ADDRESS", "BIRTH_DATE", "CELLPHONE", "CITY", "EMAIL", "GENDER", "NAME", "NEIGHBORHOOD", "NUMBER", "PASS", "ID_PROFILE", "PROFILE_PHOTO", "REGISTER_DATE", "STATE", "UPDATE_DATE", "ZIP_CODE" },
                values: new object[] { 1, true, null, new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified), null, null, "adm@adm.com.br", null, "Administrador", null, 0, "753eb493837bbbdc5e1ddc7bb182ae5924198d68", 1, null, new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified), null, new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "ID",
                keyValue: 1);

            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "ID", "ACTIVE", "ADDRESS", "BIRTH_DATE", "CELLPHONE", "CITY", "EMAIL", "GENDER", "NAME", "NEIGHBORHOOD", "NUMBER", "PASS", "ID_PROFILE", "PROFILE_PHOTO", "REGISTER_DATE", "STATE", "UPDATE_DATE", "ZIP_CODE" },
                values: new object[] { 27816234, true, null, new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified), null, null, "adm@adm.com.br", null, "Administrator", null, 0, "753eb493837bbbdc5e1ddc7bb182ae5924198d68", 1, null, new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified), null, new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified), null });
        }
    }
}
