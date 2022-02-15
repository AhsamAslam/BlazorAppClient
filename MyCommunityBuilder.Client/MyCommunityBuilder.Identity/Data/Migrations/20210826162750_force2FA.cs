using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCommunityBuilder.Identity.Data.Migrations
{
    public partial class force2FA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Force2FA",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Force2FA",
                table: "AspNetUsers");
        }
    }
}
