using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DBInitV157 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PresentationRessource",
                table: "WebSites",
                newName: "PresentationRessourceName");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                table: "WebSites",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MinAge",
                table: "WebSites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Presentation2RessourceName",
                table: "WebSites",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Presentation3RessourceName",
                table: "WebSites",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "WebSites");

            migrationBuilder.DropColumn(
                name: "MinAge",
                table: "WebSites");

            migrationBuilder.DropColumn(
                name: "Presentation2RessourceName",
                table: "WebSites");

            migrationBuilder.DropColumn(
                name: "Presentation3RessourceName",
                table: "WebSites");

            migrationBuilder.RenameColumn(
                name: "PresentationRessourceName",
                table: "WebSites",
                newName: "PresentationRessource");
        }
    }
}
