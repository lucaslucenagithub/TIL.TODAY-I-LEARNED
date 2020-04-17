using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RC.Recloti.Data.Migrations
{
    public partial class DataBaseCreation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PROFILE",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESCRIPTION = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PROFILE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_PROFILE = table.Column<int>(nullable: true),
                    NAME = table.Column<string>(type: "varchar(80)", nullable: true),
                    EMAIL = table.Column<string>(type: "varchar(80)", nullable: true),
                    PASS = table.Column<string>(type: "varchar(120)", nullable: true),
                    GENDER = table.Column<string>(type: "varchar(25)", nullable: true),
                    BIRTH_DATE = table.Column<DateTime>(nullable: false),
                    ZIP_CODE = table.Column<string>(type: "varchar(25)", nullable: true),
                    STATE = table.Column<string>(type: "varchar(50)", nullable: true),
                    CITY = table.Column<string>(type: "varchar(50)", nullable: true),
                    NEIGHBORHOOD = table.Column<string>(type: "varchar(50)", nullable: true),
                    ADDRESS = table.Column<string>(type: "varchar(80)", nullable: true),
                    NUMBER = table.Column<int>(nullable: false),
                    Cellphone = table.Column<string>(nullable: true),
                    ProfilePhoto = table.Column<string>(nullable: true),
                    ACTIVE = table.Column<bool>(nullable: false),
                    REGISTER_DATE = table.Column<DateTime>(nullable: false),
                    UPDATE_DATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USER_PROFILE_ID_PROFILE",
                        column: x => x.ID_PROFILE,
                        principalTable: "PROFILE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_USER_ID_PROFILE",
                table: "USER",
                column: "ID_PROFILE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "PROFILE");
        }
    }
}
