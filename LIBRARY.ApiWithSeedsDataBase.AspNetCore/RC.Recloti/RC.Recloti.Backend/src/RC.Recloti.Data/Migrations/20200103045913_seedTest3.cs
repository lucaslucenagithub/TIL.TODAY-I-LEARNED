using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class seedTest3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "USER",
                columns: new[] { "ID", "ACTIVE", "ADDRESS", "BIRTH_DATE", "CELLPHONE", "CITY", "EMAIL", "GENDER", "NAME", "NEIGHBORHOOD", "NUMBER", "PASS", "ID_PROFILE", "PROFILE_PHOTO", "REGISTER_DATE", "STATE", "UPDATE_DATE", "ZIP_CODE" },
                values: new object[] { 27816234, true, null, new DateTime(2020, 1, 3, 4, 59, 12, 748, DateTimeKind.Utc).AddTicks(1949), null, null, "adm@adm.com.br", null, null, null, 0, "753eb493837bbbdc5e1ddc7bb182ae5924198d68", 1, null, new DateTime(2020, 1, 3, 4, 59, 12, 748, DateTimeKind.Utc).AddTicks(1986), null, new DateTime(2020, 1, 3, 4, 59, 12, 748, DateTimeKind.Utc).AddTicks(1987), null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "USER",
                keyColumn: "ID",
                keyValue: 27816234);
        }
    }
}
