using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class seedTest5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "ID",
                keyValue: 27816234,
                columns: new[] { "BIRTH_DATE", "REGISTER_DATE", "UPDATE_DATE" },
                values: new object[] { new DateTime(2000, 1, 1, 4, 59, 12, 748, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 4, 59, 12, 748, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 4, 59, 12, 748, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "ID",
                keyValue: 27816234,
                columns: new[] { "BIRTH_DATE", "REGISTER_DATE", "UPDATE_DATE" },
                values: new object[] { new DateTime(2020, 1, 3, 5, 0, 26, 923, DateTimeKind.Utc).AddTicks(3108), new DateTime(2020, 1, 3, 5, 0, 26, 923, DateTimeKind.Utc).AddTicks(3132), new DateTime(2020, 1, 3, 5, 0, 26, 923, DateTimeKind.Utc).AddTicks(3135) });
        }
    }
}
