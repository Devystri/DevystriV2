﻿using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class DBInitV13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visits");

            migrationBuilder.DropIndex(
                name: "Idx_Name",
                table: "WebSites");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "Idx_Email",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "Idx_ProjectId",
                table: "Sections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Newsletters",
                table: "OSs");

            migrationBuilder.DropIndex(
                name: "Idx_StatId",
                table: "OSs");

            migrationBuilder.DropIndex(
                name: "Idx_ProjectId",
                table: "Newsletters");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Log",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "Idx_LogId",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "Idx_Name",
                table: "Applications");

            migrationBuilder.DropPrimaryKey(
                name: "PK_IoTs",
                table: "Iot");

            migrationBuilder.DropIndex(
                name: "Idx_Name",
                table: "Iot");

            migrationBuilder.RenameTable(
                name: "Iot",
                newName: "Iots");

            migrationBuilder.AlterColumn<string>(
                name: "PresentationRessource",
                table: "WebSites",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WebSites",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "WebSites",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WebSites",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "AppLogoName",
                table: "WebSites",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDateTime",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Sections",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sections",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "OsName",
                table: "OSs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Newsletters",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Newsletters",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Logs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Logs",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime");

            migrationBuilder.AlterColumn<string>(
                name: "PresentationRessource",
                table: "Applications",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Applications",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<int>(
                name: "IsOnPlayStore",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(1)");

            migrationBuilder.AlterColumn<int>(
                name: "IsOnAppStore",
                table: "Applications",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int(1)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Applications",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");

            migrationBuilder.AlterColumn<string>(
                name: "AppLogoName",
                table: "Applications",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "PresentationRessource",
                table: "Iots",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Iots",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Iots",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OSs",
                table: "OSs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Iots",
                table: "Iots",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OSs",
                table: "OSs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Iots",
                table: "Iots");

            migrationBuilder.RenameTable(
                name: "Iots",
                newName: "Iot");

            migrationBuilder.AlterColumn<string>(
                name: "PresentationRessource",
                table: "WebSites",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "WebSites",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Link",
                table: "WebSites",
                type: "nvarchar(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "WebSites",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AppLogoName",
                table: "WebSites",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdateDateTime",
                table: "Users",
                type: "datetime",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Users",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreationDateTime",
                table: "Users",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Sections",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Sections",
                type: "nvarchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "OsName",
                table: "OSs",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Newsletters",
                type: "nvarchar(300)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Newsletters",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "Message",
                table: "Logs",
                type: "nvarchar(1000)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Logs",
                type: "datetime",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AlterColumn<string>(
                name: "PresentationRessource",
                table: "Applications",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Applications",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "IsOnPlayStore",
                table: "Applications",
                type: "int(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "IsOnAppStore",
                table: "Applications",
                type: "int(1)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Applications",
                type: "nvarchar(500)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "AppLogoName",
                table: "Applications",
                type: "nvarchar(200)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "PresentationRessource",
                table: "Iot",
                type: "nvarchar(200)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Iot",
                type: "nvarchar(100)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Iot",
                type: "nvarchar(500)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Newsletters",
                table: "OSs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Log",
                table: "Logs",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_IoTs",
                table: "Iot",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Visits",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Count = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    Page = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "Idx_Name",
                table: "WebSites",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_ProjectId",
                table: "Sections",
                column: "ProjectId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_StatId",
                table: "OSs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_ProjectId",
                table: "Newsletters",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_LogId",
                table: "Logs",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_Name",
                table: "Applications",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_Name",
                table: "Iot",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "Idx_StatId",
                table: "Visits",
                column: "Id",
                unique: true);
        }
    }
}
