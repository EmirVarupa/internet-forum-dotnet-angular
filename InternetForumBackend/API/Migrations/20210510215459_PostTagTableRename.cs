using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class PostTagTableRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags");

            migrationBuilder.DropForeignKey(
                name: "FK_PostTags_Tags_TagId",
                table: "PostTags");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags");

            migrationBuilder.RenameTable(
                name: "PostTags",
                newName: "Post_Tag");

            migrationBuilder.RenameIndex(
                name: "IX_PostTags_TagId",
                table: "Post_Tag",
                newName: "IX_Post_Tag_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post_Tag",
                table: "Post_Tag",
                columns: new[] { "PostId", "TagId" });

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Tag_Posts_PostId",
                table: "Post_Tag");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Tag_Tags_TagId",
                table: "Post_Tag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post_Tag",
                table: "Post_Tag");

            migrationBuilder.RenameTable(
                name: "Post_Tag",
                newName: "PostTags");

            migrationBuilder.RenameIndex(
                name: "IX_Post_Tag_TagId",
                table: "PostTags",
                newName: "IX_PostTags_TagId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PostTags",
                table: "PostTags",
                columns: new[] { "PostId", "TagId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Posts_PostId",
                table: "PostTags",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "PostId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PostTags_Tags_TagId",
                table: "PostTags",
                column: "TagId",
                principalTable: "Tags",
                principalColumn: "TagId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
