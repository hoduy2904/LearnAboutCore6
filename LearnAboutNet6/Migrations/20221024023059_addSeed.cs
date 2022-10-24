using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnAboutNet6.Migrations
{
    public partial class addSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd5901f8-c187-46f2-b253-e5610c1e6b16");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a21ca373-d6e7-4468-a3d3-c08a7c250035");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7af5f491-152e-4063-b721-0d91096d6f96", "1b48212c-afad-4115-8edd-b8b02d8b9c48", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9481ed98-2610-4d4d-9055-7a639d79a697", 0, "16a9e056-bb76-489f-b49b-6854fcde0238", null, true, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEISVmykjHAVUYWyKEkAcC8NsvOfHJdxHUDRGrYmDXjPOi5BzwQwJEJ/umd+Yyhf8gA==", null, false, "7cf22bca-e7bb-4fe5-a4a8-5c92d671856f", false, "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7af5f491-152e-4063-b721-0d91096d6f96", "9481ed98-2610-4d4d-9055-7a639d79a697" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7af5f491-152e-4063-b721-0d91096d6f96", "9481ed98-2610-4d4d-9055-7a639d79a697" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7af5f491-152e-4063-b721-0d91096d6f96");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9481ed98-2610-4d4d-9055-7a639d79a697");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd5901f8-c187-46f2-b253-e5610c1e6b16", "74545ab1-03c9-4f57-9d07-e1cba1f3b7e5", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "a21ca373-d6e7-4468-a3d3-c08a7c250035", 0, "bb4a8f30-99df-48de-9dca-ac6d52a7cf05", null, false, false, null, null, null, "AQAAAAEAACcQAAAAEEr4+zbXqNGkM0JKTEGCsahh3Xc2GV4kdMlE5AE2WuK8TLYPQU4WihuR0iQKmiNr3Q==", null, false, "97278421-424a-499e-9069-ace73f30c91c", false, "admin" });
        }
    }
}
