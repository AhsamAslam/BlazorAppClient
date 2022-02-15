using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCommunityBuilder.Identity.Data.Migrations
{
    public partial class initName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
            migrationBuilder.AddColumn<string>(
               name: "FirstName",
               table: "AspNetUsers",
               type: "nvarchar(250)",
               nullable: true);
            migrationBuilder.AddColumn<string>(
               name: "LastName",
               table: "AspNetUsers",
               type: "nvarchar(250)",
               nullable: true);
            migrationBuilder.AddColumn<string>(
               name: "Type",
               table: "AspNetUsers",
               type: "nvarchar(50)",
               nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "AspNetUsers");
        }
    }
}
