using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.App.EF.Migrations
{
    public partial class NewTranslations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaterialName",
                table: "Materials");

            migrationBuilder.AddColumn<int>(
                name: "MaterialNameId",
                table: "Materials",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Materials_MaterialNameId",
                table: "Materials",
                column: "MaterialNameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Materials_MultiLangStrings_MaterialNameId",
                table: "Materials",
                column: "MaterialNameId",
                principalTable: "MultiLangStrings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Materials_MultiLangStrings_MaterialNameId",
                table: "Materials");

            migrationBuilder.DropIndex(
                name: "IX_Materials_MaterialNameId",
                table: "Materials");

            migrationBuilder.DropColumn(
                name: "MaterialNameId",
                table: "Materials");

            migrationBuilder.AddColumn<string>(
                name: "MaterialName",
                table: "Materials",
                nullable: true);
        }
    }
}
