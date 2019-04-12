using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.App.EF.Migrations
{
    public partial class MoreChanges5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Schoolings_Participants_ParticipantId",
                table: "Schoolings");

            migrationBuilder.DropIndex(
                name: "IX_Schoolings_ParticipantId",
                table: "Schoolings");

            migrationBuilder.DropColumn(
                name: "ParticipantId",
                table: "Schoolings");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ParticipantId",
                table: "Schoolings",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Schoolings_ParticipantId",
                table: "Schoolings",
                column: "ParticipantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Schoolings_Participants_ParticipantId",
                table: "Schoolings",
                column: "ParticipantId",
                principalTable: "Participants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
