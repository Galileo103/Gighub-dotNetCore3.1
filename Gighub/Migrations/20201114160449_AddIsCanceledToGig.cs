using Microsoft.EntityFrameworkCore.Migrations;

namespace Gighub.Migrations
{
    public partial class AddIsCanceledToGig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "iscanceled",
                table: "gigs",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "iscanceled",
                table: "gigs");
        }
    }
}
