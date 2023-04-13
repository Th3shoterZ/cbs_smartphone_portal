using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphonePortal_Vervoort_Wagner.Server.Migrations
{
    public partial class add_username_to_review : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Reviews",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Reviews");
        }
    }
}
