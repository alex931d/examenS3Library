using Microsoft.EntityFrameworkCore.Migrations;

namespace repostory.Migrations
{
    public partial class Libarys3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Passowrd",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "Passowrd",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
