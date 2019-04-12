using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.App.EF.Migrations
{
    public partial class MoreChanges4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schoolings_Dogs_DogId",
                table: "Schoolings");

            migrationBuilder.DropIndex(
                name: "IX_Schoolings_DogId",
                table: "Schoolings");

            migrationBuilder.DropColumn(
                name: "DogId",
                table: "Schoolings");

            migrationBuilder.AlterColumn<string>(
                name: "SchoolingName",
                table: "Schoolings",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Schoolings",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SchoolingName",
                table: "Schoolings",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "MaterialId",
                table: "Schoolings",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DogId",
                table: "Schoolings",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Schoolings_DogId",
                table: "Schoolings",
                column: "DogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schoolings_Dogs_DogId",
                table: "Schoolings",
                column: "DogId",
                principalTable: "Dogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
