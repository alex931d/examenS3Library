using Microsoft.EntityFrameworkCore.Migrations;

namespace repostory.Migrations
{
    public partial class librys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_roles_Users_usersId",
                table: "roles");

            migrationBuilder.DropIndex(
                name: "IX_roles_usersId",
                table: "roles");

            migrationBuilder.DropColumn(
                name: "usersId",
                table: "roles");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "usersId",
                table: "roles",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_roles_usersId",
                table: "roles",
                column: "usersId");

            migrationBuilder.AddForeignKey(
                name: "FK_roles_Users_usersId",
                table: "roles",
                column: "usersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
