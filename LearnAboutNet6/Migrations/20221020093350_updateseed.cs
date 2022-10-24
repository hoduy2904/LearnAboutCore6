using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnAboutNet6.Migrations
{
    public partial class updateseed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { "7af5f491-152e-4063-b721-0d91096d6f96", "f1d0db57-a41b-4ef1-9737-c25e0529107a", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9481ed98-2610-4d4d-9055-7a639d79a697", 0, "a6706fa7-a38e-4dc9-b1fb-00c1538cc05f", null, false, false, null, null, null, null, null, false, "0eac95b4-cbd3-4452-b346-95ae5013e0c2", false, "admin" });
        }
    }
}
