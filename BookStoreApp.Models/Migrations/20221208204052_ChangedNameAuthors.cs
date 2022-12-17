using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreApp.Data.Migrations
{
    public partial class ChangedNameAuthors : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Authors");

            migrationBuilder.RenameColumn(
                name: "LastName",
                table: "Authors",
                newName: "FullName");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8afe7fcf-2a2e-4a9c-9c07-fba463991e60"),
                column: "FullName",
                value: "Charles Bukowski");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d41abf04-8d6f-4d23-bfe2-75cc72d6eac4"),
                column: "FullName",
                value: "Jack London");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Authors",
                newName: "LastName");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Authors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("8afe7fcf-2a2e-4a9c-9c07-fba463991e60"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Charles", "Bukowski" });

            migrationBuilder.UpdateData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: new Guid("d41abf04-8d6f-4d23-bfe2-75cc72d6eac4"),
                columns: new[] { "FirstName", "LastName" },
                values: new object[] { "Jack", "Lodon" });
        }
    }
}
