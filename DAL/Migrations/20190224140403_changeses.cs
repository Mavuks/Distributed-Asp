using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class changeses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Dogs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Owner",
                table: "Dogs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Dogs_AppUserId",
                table: "Dogs",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Dogs_AspNetUsers_AppUserId",
                table: "Dogs",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Dogs_AspNetUsers_AppUserId",
                table: "Dogs");

            migrationBuilder.DropIndex(
                name: "IX_Dogs_AppUserId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Dogs");

            migrationBuilder.DropColumn(
                name: "Owner",
                table: "Dogs");
        }
    }
}
