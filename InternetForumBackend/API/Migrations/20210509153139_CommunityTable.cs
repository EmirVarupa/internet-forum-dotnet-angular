using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CommunityTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Communities",
                columns: table => new
                {
                    CommunityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunityTypeId = table.Column<int>(type: "int", nullable: false),
                    CommunityName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CommunitySummary = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Communities", x => x.CommunityId);
                    table.ForeignKey(
                        name: "FK_Communities_CommunityTypes_CommunityTypeId",
                        column: x => x.CommunityTypeId,
                        principalTable: "CommunityTypes",
                        principalColumn: "TypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Communities_CommunityTypeId",
                table: "Communities",
                column: "CommunityTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Communities");
        }
    }
}
