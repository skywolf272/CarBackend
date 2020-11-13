using Microsoft.EntityFrameworkCore.Migrations;

namespace TestedaApplication.Migrations
{
    public partial class repairFav2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Favourites",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F1dfb214e2",
                column: "ConcurrencyStamp",
                value: "b8419a39-6fbb-4a95-96cd-6c57c8d09b31");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Favourites",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F1dfb214e2",
                column: "ConcurrencyStamp",
                value: "a1bb6f59-d2b2-4a44-b5f4-b90349151d42");
        }
    }
}
