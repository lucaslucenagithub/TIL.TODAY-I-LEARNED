using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class seedTest4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "ID",
                keyValue: 27816234,
                columns: new[] { "BIRTH_DATE", "NAME", "REGISTER_DATE", "UPDATE_DATE" },
                values: new object[] { new DateTime(2020, 1, 3, 5, 0, 26, 923, DateTimeKind.Utc).AddTicks(3108), "Administrator", new DateTime(2020, 1, 3, 5, 0, 26, 923, DateTimeKind.Utc).AddTicks(3132), new DateTime(2020, 1, 3, 5, 0, 26, 923, DateTimeKind.Utc).AddTicks(3135) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "ID",
                keyValue: 27816234,
                columns: new[] { "BIRTH_DATE", "NAME", "REGISTER_DATE", "UPDATE_DATE" },
                values: new object[] { new DateTime(2020, 1, 3, 4, 59, 12, 748, DateTimeKind.Utc).AddTicks(1949), null, new DateTime(2020, 1, 3, 4, 59, 12, 748, DateTimeKind.Utc).AddTicks(1986), new DateTime(2020, 1, 3, 4, 59, 12, 748, DateTimeKind.Utc).AddTicks(1987) });
        }
    }
}
