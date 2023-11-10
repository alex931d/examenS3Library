using Microsoft.EntityFrameworkCore.Migrations;

namespace repostory.Migrations
{
    public partial class Libarys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Passowrd",
                table: "Users",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UsernameId",
                table: "Users",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passowrd",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UsernameId",
                table: "Users");
        }
    }
}
