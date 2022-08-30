using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class PostVotesUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Tag_Posts_PostId",
                table: "Post_Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Tag_Tags_TagId",
                table: "Post_Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_PostVotes_Users_UserId",
                table: "PostVotes");

            migrationBuilder.DropIndex(
                name: "IX_PostVotes_UserId",
                table: "PostVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_Tag",
                table: "Post_Tag");

            migrationBuilder.RenameTable(
                name: "Post_Tag",
                newName: "Posts_Tags");

            migrationBuilder.RenameIndex(
                name: "IX_Post_Tag_TagId",
                table: "Posts_Tags",
                newName: "IX_Posts_Tags_TagId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PostVotes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts_Tags",
                table: "Posts_Tags",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.CreateTable(
                name: "Users_PostVotes",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostVoteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_PostVotes", x => new { x.UserId, x.PostVoteId });
                    table.ForeignKey(
                        name: "FK_Users_PostVotes_PostVotes_PostVoteId",
                        column: x => x.PostVoteId,
                        principalTable: "PostVotes",
                        principalColumn: "VoteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_PostVotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_PostVotes_PostVoteId",
                table: "Users_PostVotes",
                column: "PostVoteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tags_Posts_PostId",
                table: "Posts_Tags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Tags_Tags_TagId",
                table: "Posts_Tags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tags_Posts_PostId",
                table: "Posts_Tags");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Tags_Tags_TagId",
                table: "Posts_Tags");

            migrationBuilder.DropTable(
                name: "Users_PostVotes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts_Tags",
                table: "Posts_Tags");

            migrationBuilder.RenameTable(
                name: "Posts_Tags",
                newName: "Post_Tag");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_Tags_TagId",
                table: "Post_Tag",
                newName: "IX_Post_Tag_TagId");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "PostVotes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_Tag",
                table: "Post_Tag",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.CreateIndex(
                name: "IX_PostVotes_UserId",
                table: "PostVotes",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Tag_Posts_PostId",
                table: "Post_Tag",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Tag_Tags_TagId",
                table: "Post_Tag",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostVotes_Users_UserId",
                table: "PostVotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
