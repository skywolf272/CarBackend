using Microsoft.EntityFrameworkCore.Migrations;

namespace TestedaApplication.Migrations
{
    public partial class AddUserrRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "F1dfb214e2", "481f82e0-5bac-45e7-bc12-a945552c9e4b", "user", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F1dfb214e2");
        }
    }
}
