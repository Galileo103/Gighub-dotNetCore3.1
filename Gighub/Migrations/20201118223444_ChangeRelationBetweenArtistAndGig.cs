using Microsoft.EntityFrameworkCore.Migrations;

namespace Gighub.Migrations
{
    public partial class ChangeRelationBetweenArtistAndGig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_gigs_artistid",
                table: "gigs");

            migrationBuilder.CreateIndex(
                name: "IX_gigs_artistid",
                table: "gigs",
                column: "artistid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_gigs_artistid",
                table: "gigs");

            migrationBuilder.CreateIndex(
                name: "IX_gigs_artistid",
                table: "gigs",
                column: "artistid",
                unique: true);
        }
    }
}
