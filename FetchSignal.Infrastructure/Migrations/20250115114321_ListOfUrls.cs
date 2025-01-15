using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FetchSignal.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ListOfUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ApplicationName",
                table: "ListedUrls",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "ListedUrls",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "ListedUrls",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Extension",
                table: "ListedUrls",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IsActive",
                table: "ListedUrls",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "ListedUrls",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApplicationName",
                table: "ListedUrls");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "ListedUrls");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "ListedUrls");

            migrationBuilder.DropColumn(
                name: "Extension",
                table: "ListedUrls");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "ListedUrls");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "ListedUrls");
        }
    }
}
