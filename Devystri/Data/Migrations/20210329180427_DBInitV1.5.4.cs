using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DBInitV154 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PresentationRessource",
                table: "Applications",
                newName: "PresentationRessourceName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PresentationRessourceName",
                table: "Applications",
                newName: "PresentationRessource");
        }
    }
}
