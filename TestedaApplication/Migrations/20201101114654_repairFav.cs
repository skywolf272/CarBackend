using Microsoft.EntityFrameworkCore.Migrations;

namespace TestedaApplication.Migrations
{
    public partial class repairFav : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_Cars_CarId",
                table: "Favourites");

            migrationBuilder.DropForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId1",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_CarId",
                table: "Favourites");

            migrationBuilder.DropIndex(
                name: "IX_Favourites_UserId1",
                table: "Favourites");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Favourites");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F1dfb214e2",
                column: "ConcurrencyStamp",
                value: "a1bb6f59-d2b2-4a44-b5f4-b90349151d42");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Favourites",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "F1dfb214e2",
                column: "ConcurrencyStamp",
                value: "481f82e0-5bac-45e7-bc12-a945552c9e4b");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_CarId",
                table: "Favourites",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_Favourites_UserId1",
                table: "Favourites",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_Cars_CarId",
                table: "Favourites",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Favourites_AspNetUsers_UserId1",
                table: "Favourites",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
