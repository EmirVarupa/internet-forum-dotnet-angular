using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class UserPostCommentVote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PostCommentVotes",
                columns: table => new
                {
                    VoteId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VoteCount = table.Column<int>(type: "int", nullable: false),
                    CommentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostCommentVotes", x => x.VoteId);
                    table.ForeignKey(
                        name: "FK_PostCommentVotes_PostComments_CommentId",
                        column: x => x.CommentId,
                        principalTable: "PostComments",
                        principalColumn: "CommentId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users_PostCommentVotes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostCommentVoteId = table.Column<int>(type: "int", nullable: false),
                    PostCommentVoteDirection = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_PostCommentVotes", x => new { x.UserId, x.PostCommentVoteId });
                    table.ForeignKey(
                        name: "FK_Users_PostCommentVotes_PostCommentVotes_PostCommentVoteId",
                        column: x => x.PostCommentVoteId,
                        principalTable: "PostCommentVotes",
                        principalColumn: "VoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_PostCommentVotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PostCommentVotes_CommentId",
                table: "PostCommentVotes",
                column: "CommentId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostCommentVotes_PostCommentVoteId",
                table: "Users_PostCommentVotes",
                column: "PostCommentVoteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users_PostCommentVotes");

            migrationBuilder.DropTable(
                name: "PostCommentVotes");
        }
    }
}
