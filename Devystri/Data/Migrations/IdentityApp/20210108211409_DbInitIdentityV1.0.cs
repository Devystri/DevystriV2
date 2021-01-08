using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations.IdentityApp
{
    public partial class DbInitIdentityV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "AspNetUsers",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "AspNetUsers");
        }
    }
}
