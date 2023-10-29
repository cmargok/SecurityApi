using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Security.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class deleteivandcodeaccess : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "accaa5ee-0d04-4fea-a3a8-198c07977ad0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "eead93b4-f076-4655-8af7-5e8c15de9af5");

            migrationBuilder.DropColumn(
                name: "AccessCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CodeIV",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "PreRegister",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "UserRegistrationSecretCode",
                table: "PreRegister",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "19786cf1-c397-4829-9117-60be4356dd89", null, "User", "USER" },
                    { "3e345381-3d5c-4def-9cfd-93cb8c4b9e47", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19786cf1-c397-4829-9117-60be4356dd89");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3e345381-3d5c-4def-9cfd-93cb8c4b9e47");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "PreRegister");

            migrationBuilder.DropColumn(
                name: "UserRegistrationSecretCode",
                table: "PreRegister");

            migrationBuilder.AddColumn<string>(
                name: "AccessCode",
                table: "AspNetUsers",
                type: "nvarchar(128)",
                maxLength: 128,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CodeIV",
                table: "AspNetUsers",
                type: "nvarchar(32)",
                maxLength: 32,
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "accaa5ee-0d04-4fea-a3a8-198c07977ad0", null, "User", "USER" },
                    { "eead93b4-f076-4655-8af7-5e8c15de9af5", null, "Admin", "ADMIN" }
                });
        }
    }
}
