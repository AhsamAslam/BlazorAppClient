using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCommunityBuilder.Identity.Data.Migrations
{
    public partial class Was2faEnabledInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Was2faEnabledInit",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Was2faEnabledInit",
                table: "AspNetUsers");
        }
    }
}
