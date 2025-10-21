using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Security.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class NewHashImplementation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {            

            migrationBuilder.EnsureSchema(
                name: "logAudit");

            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.RenameTable(
                name: "PreRegister",
                newName: "PreRegister",
                newSchema: "dbo");

            migrationBuilder.AddColumn<string>(
                name: "NoHashedUserName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "HashUserName",
                schema: "dbo",
                table: "PreRegister",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoHashedUserName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HashUserName",
                schema: "dbo",
                table: "PreRegister");

            migrationBuilder.RenameTable(
                name: "PreRegister",
                schema: "dbo",
                newName: "PreRegister");

         
        }
    }
}
