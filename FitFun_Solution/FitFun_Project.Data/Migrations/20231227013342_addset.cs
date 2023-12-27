using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitFun_Project.Data.Migrations
{
    public partial class addset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id",
                table: "teachersData",
                newName: "ID");

            migrationBuilder.CreateTable(
                name: "lessonsData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    price = table.Column<int>(type: "int", nullable: false),
                    startHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    endHour = table.Column<DateTime>(type: "datetime2", nullable: false),
                    teacherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lessonsData", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "participantsData",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_participantsData", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lessonsData");

            migrationBuilder.DropTable(
                name: "participantsData");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "teachersData",
                newName: "id");
        }
    }
}
