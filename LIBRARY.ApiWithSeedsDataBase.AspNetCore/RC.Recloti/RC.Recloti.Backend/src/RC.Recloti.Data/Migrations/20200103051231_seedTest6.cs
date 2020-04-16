using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class seedTest6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "ID",
                keyValue: 27816234,
                columns: new[] { "BIRTH_DATE", "REGISTER_DATE", "UPDATE_DATE" },
                values: new object[] { new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified), new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified), new DateTime(1111, 1, 1, 1, 11, 11, 111, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "USER",
                keyColumn: "ID",
                keyValue: 27816234,
                columns: new[] { "BIRTH_DATE", "REGISTER_DATE", "UPDATE_DATE" },
                values: new object[] { new DateTime(2000, 1, 1, 4, 59, 12, 748, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 4, 59, 12, 748, DateTimeKind.Unspecified), new DateTime(2000, 1, 1, 4, 59, 12, 748, DateTimeKind.Unspecified) });
        }
    }
}
