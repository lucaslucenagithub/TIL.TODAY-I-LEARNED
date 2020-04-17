using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class userupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cellphone",
                table: "USER",
                newName: "CELLPHONE");

            migrationBuilder.RenameColumn(
                name: "ProfilePhoto",
                table: "USER",
                newName: "PROFILE_PHOTO");

            migrationBuilder.AlterColumn<string>(
                name: "CELLPHONE",
                table: "USER",
                type: "varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "PROFILE",
                type: "varchar(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CELLPHONE",
                table: "USER",
                newName: "Cellphone");

            migrationBuilder.RenameColumn(
                name: "PROFILE_PHOTO",
                table: "USER",
                newName: "ProfilePhoto");

            migrationBuilder.AlterColumn<string>(
                name: "Cellphone",
                table: "USER",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DESCRIPTION",
                table: "PROFILE",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(25)",
                oldNullable: true);
        }
    }
}
