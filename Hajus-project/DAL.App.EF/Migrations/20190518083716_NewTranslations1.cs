using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.App.EF.Migrations
{
    public partial class NewTranslations1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Locations",
                table: "Locations");

            migrationBuilder.AddColumn<int>(
                name: "LocationsId",
                table: "Locations",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LocationsId",
                table: "Locations",
                column: "LocationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_MultiLangStrings_LocationsId",
                table: "Locations",
                column: "LocationsId",
                principalTable: "MultiLangStrings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_MultiLangStrings_LocationsId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_LocationsId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationsId",
                table: "Locations");

            migrationBuilder.AddColumn<string>(
                name: "Locations",
                table: "Locations",
                nullable: true);
        }
    }
}
