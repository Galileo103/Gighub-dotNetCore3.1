using Microsoft.EntityFrameworkCore.Migrations;

namespace Gighub.Migrations
{
    public partial class AddFollowingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "followings",
                columns: table => new
                {
                    followerid = table.Column<string>(nullable: false),
                    followeeid = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_followings", x => new { x.followerid, x.followeeid });
                    table.ForeignKey(
                        name: "FK_followings_aspnetusers_followeeid",
                        column: x => x.followeeid,
                        principalTable: "aspnetusers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_followings_aspnetusers_followerid",
                        column: x => x.followerid,
                        principalTable: "aspnetusers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_followings_followeeid",
                table: "followings",
                column: "followeeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "followings");
        }
    }
}
