using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphonePortalVervoortWagner.Server.Data.Migrations
{
    /// <inheritdoc />
    public partial class CreateSmartphone : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Smarthpone",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(128)", nullable: true),
                });
        }
    }
}
