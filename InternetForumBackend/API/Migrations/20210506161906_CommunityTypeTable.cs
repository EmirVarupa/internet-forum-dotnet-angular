using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CommunityTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "CommunityTypes",
                table => new
                {
                    TypeId = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeName = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_CommunityTypes", x => x.TypeId); });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "CommunityTypes");
        }
    }
}