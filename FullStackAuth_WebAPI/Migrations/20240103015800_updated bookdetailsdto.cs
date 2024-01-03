using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FullStackAuth_WebAPI.Migrations
{
    /// <inheritdoc />
    public partial class updatedbookdetailsdto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "331e216a-58a4-49b5-a275-75e42aca638e");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "3effc2f9-21c0-4567-8557-940fa8aabc9d");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "164a1e40-a9bb-4d0f-a8ea-ebc5b64a8504", null, "User", "USER" },
                    { "b967fdf2-d4e6-4dca-af87-6f0fa8a582b9", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "164a1e40-a9bb-4d0f-a8ea-ebc5b64a8504");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "b967fdf2-d4e6-4dca-af87-6f0fa8a582b9");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "331e216a-58a4-49b5-a275-75e42aca638e", null, "User", "USER" },
                    { "3effc2f9-21c0-4567-8557-940fa8aabc9d", null, "Admin", "ADMIN" }
                });
        }
    }
}
