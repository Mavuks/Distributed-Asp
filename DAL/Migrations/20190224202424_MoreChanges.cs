using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MoreChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Award",
                table: "Shows");

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Registrations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CompetitionId",
                table: "Registrations",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "AwardId",
                table: "Dogs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Awards",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Place",
                table: "Awards",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "CompetitionId",
                table: "Awards",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Award",
                table: "Shows",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Registrations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompetitionId",
                table: "Registrations",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AwardId",
                table: "Dogs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ShowId",
                table: "Awards",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Place",
                table: "Awards",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CompetitionId",
                table: "Awards",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
