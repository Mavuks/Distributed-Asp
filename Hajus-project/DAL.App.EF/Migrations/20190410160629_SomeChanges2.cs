using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.App.EF.Migrations
{
    public partial class SomeChanges2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shows_Participants_ParticipantId",
                table: "Shows");

            migrationBuilder.DropIndex(
                name: "IX_Shows_ParticipantId",
                table: "Shows");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Shows");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "Shows",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Shows_ParticipantId",
                table: "Shows",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shows_Participants_ParticipantId",
                table: "Shows",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
