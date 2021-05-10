using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class UserCommunityAdminsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users_CommunityAdmin",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    CommunityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_CommunityAdmin", x => new { x.CommunityId, x.UserId });
                    table.ForeignKey(
                        name: "FK_Users_CommunityAdmin_Communities_CommunityId",
                        column: x => x.CommunityId,
                        principalTable: "Communities",
                        principalColumn: "CommunityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_CommunityAdmin_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_CommunityAdmin_UserId",
                table: "Users_CommunityAdmin",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_CommunityAdmin");
        }
    }
}
