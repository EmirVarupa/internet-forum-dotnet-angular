using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UserCommunity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Communities_Roles_RoleId",
                table: "Users_Communities");

            migrationBuilder.DropIndex(
                name: "IX_Users_Communities_RoleId",
                table: "Users_Communities");

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users_Communities");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users_Communities",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Communities_RoleId",
                table: "Users_Communities",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Communities_Roles_RoleId",
                table: "Users_Communities",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId");
        }
    }
}
