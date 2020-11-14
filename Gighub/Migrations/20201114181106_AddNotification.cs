using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Gighub.Migrations
{
    public partial class AddNotification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "notifications",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    notificationtype = table.Column<int>(nullable: false),
                    datetime = table.Column<DateTime>(nullable: false),
                    originaldatetime = table.Column<DateTime>(nullable: true),
                    originalvenue = table.Column<string>(nullable: true),
                    gigid = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_notifications", x => x.id);
                    table.ForeignKey(
                        name: "FK_notifications_gigs_gigid",
                        column: x => x.gigid,
                        principalTable: "gigs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usernotifications",
                columns: table => new
                {
                    userid = table.Column<string>(nullable: false),
                    notificationid = table.Column<int>(nullable: false),
                    isread = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usernotifications", x => new { x.userid, x.notificationid });
                    table.ForeignKey(
                        name: "FK_usernotifications_notifications_notificationid",
                        column: x => x.notificationid,
                        principalTable: "notifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_usernotifications_aspnetusers_userid",
                        column: x => x.userid,
                        principalTable: "aspnetusers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_notifications_gigid",
                table: "notifications",
                column: "gigid");

            migrationBuilder.CreateIndex(
                name: "IX_usernotifications_notificationid",
                table: "usernotifications",
                column: "notificationid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usernotifications");

            migrationBuilder.DropTable(
                name: "notifications");
        }
    }
}
