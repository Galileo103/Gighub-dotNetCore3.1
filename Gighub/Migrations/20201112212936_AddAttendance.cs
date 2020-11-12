using Microsoft.EntityFrameworkCore.Migrations;

namespace Gighub.Migrations
{
    public partial class AddAttendance : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "attendances",
                columns: table => new
                {
                    gigid = table.Column<int>(nullable: false),
                    attendeeid = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_attendances", x => new { x.gigid, x.attendeeid });
                    table.ForeignKey(
                        name: "FK_attendances_aspnetusers_attendeeid",
                        column: x => x.attendeeid,
                        principalTable: "aspnetusers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_attendances_gigs_gigid",
                        column: x => x.gigid,
                        principalTable: "gigs",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_attendances_attendeeid",
                table: "attendances",
                column: "attendeeid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "attendances");
        }
    }
}
