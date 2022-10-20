using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LearnAboutNet6.Migrations
{
    public partial class seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7af5f491-152e-4063-b721-0d91096d6f96", "f1d0db57-a41b-4ef1-9737-c25e0529107a", "Admin", "admin" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "9481ed98-2610-4d4d-9055-7a639d79a697", 0, "a6706fa7-a38e-4dc9-b1fb-00c1538cc05f", null, false, false, null, null, null, null, null, false, "0eac95b4-cbd3-4452-b346-95ae5013e0c2", false, "admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7af5f491-152e-4063-b721-0d91096d6f96");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9481ed98-2610-4d4d-9055-7a639d79a697");
        }
    }
}
