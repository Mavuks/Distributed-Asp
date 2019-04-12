using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.App.EF.Migrations
{
    public partial class MoreChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Dogs_DogId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_DogId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Shows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_DogId",
                table: "Shows",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Dogs_DogId",
                table: "Shows",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
