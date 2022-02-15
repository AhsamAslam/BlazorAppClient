using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCommunityBuilder.Identity.Data.Migrations
{
    public partial class ImageBase64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageBase64",
                table: "AspNetUsers",
                type: "nvarchar(MAX)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageBase64",
                table: "AspNetUsers");
        }
    }
}
