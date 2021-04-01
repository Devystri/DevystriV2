using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DBInitV158 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PresentationRessource",
                table: "Iots",
                newName: "PresentationRessourceName");

            migrationBuilder.AddColumn<string>(
                name: "LogoName",
                table: "Iots",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Presentation2RessourceName",
                table: "Iots",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Presentation3RessourceName",
                table: "Iots",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LogoName",
                table: "Iots");

            migrationBuilder.DropColumn(
                name: "Presentation2RessourceName",
                table: "Iots");

            migrationBuilder.DropColumn(
                name: "Presentation3RessourceName",
                table: "Iots");

            migrationBuilder.RenameColumn(
                name: "PresentationRessourceName",
                table: "Iots",
                newName: "PresentationRessource");
        }
    }
}
