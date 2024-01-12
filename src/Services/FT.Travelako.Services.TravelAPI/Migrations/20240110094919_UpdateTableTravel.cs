using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FT.Travelako.Services.TravelAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateTableTravel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "Modified",
                table: "Travels",
                newName: "CreatedDate");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "LastModifiedBy",
                table: "Travels",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "Travels",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Travels");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "Travels");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "Travels",
                newName: "Modified");

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatedBy",
                table: "Travels",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Travels",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
