using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.App.EF.Migrations
{
    public partial class SomeChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Participants_AspNetUsers_AppUserId",
                table: "Participants");

            migrationBuilder.DropIndex(
                name: "IX_Participants_AppUserId",
                table: "Participants");

            migrationBuilder.DropColumn(
                name: "AppUserId",
                table: "Participants");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AppUserId",
                table: "Participants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Participants_AppUserId",
                table: "Participants",
                column: "AppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Participants_AspNetUsers_AppUserId",
                table: "Participants",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
