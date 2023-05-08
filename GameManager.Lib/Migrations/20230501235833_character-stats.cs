using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace GameManager.Lib.Migrations
{
    /// <inheritdoc />
    public partial class characterstats : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Constitution",
                schema: "Game",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dexterity",
                schema: "Game",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Intelligence",
                schema: "Game",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                schema: "Game",
                table: "Player",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Constitution",
                schema: "Game",
                table: "Mob",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Dexterity",
                schema: "Game",
                table: "Mob",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Intelligence",
                schema: "Game",
                table: "Mob",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Strength",
                schema: "Game",
                table: "Mob",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                schema: "Account",
                table: "AccountType",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsActive", "IsDeleted", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, "Player", 0 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, "GM", 0 }
                });

            migrationBuilder.InsertData(
                schema: "Game",
                table: "Race",
                columns: new[] { "Id", "DateCreated", "DateModified", "IsActive", "IsDeleted", "Name", "SortOrder" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, "Human", 0 },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, "Elf", 0 },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, "Drawf", 0 },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, true, false, "Orc", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Account",
                table: "AccountType",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Account",
                table: "AccountType",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Game",
                table: "Race",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Game",
                table: "Race",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Game",
                table: "Race",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Game",
                table: "Race",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "Constitution",
                schema: "Game",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Dexterity",
                schema: "Game",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Intelligence",
                schema: "Game",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Strength",
                schema: "Game",
                table: "Player");

            migrationBuilder.DropColumn(
                name: "Constitution",
                schema: "Game",
                table: "Mob");

            migrationBuilder.DropColumn(
                name: "Dexterity",
                schema: "Game",
                table: "Mob");

            migrationBuilder.DropColumn(
                name: "Intelligence",
                schema: "Game",
                table: "Mob");

            migrationBuilder.DropColumn(
                name: "Strength",
                schema: "Game",
                table: "Mob");
        }
    }
}
