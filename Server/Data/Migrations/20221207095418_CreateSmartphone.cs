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
                    Category = table.Column<string>(type: "nvarchar(128)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartphone", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhoneDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    ManufacturorInfo = table.Column<string>(type: "nvarchar(400)", nullable: false),
                    DisplaySize = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(64)", nullable: false),
                    Weight = table.Column<string>(type: "nvarchar(64)", nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
               name: "Picture",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false),
                   Title = table.Column<string>(type: "nvarchar(128)", nullable: false),
                   RelativePath = table.Column<string>(type: "nvarchar(128)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Picture", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Processor",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false),
                   Title = table.Column<string>(type: "nvarchar(64)", nullable: false),
                   CoreCount = table.Column<string>(type: "nvarchar(64)", nullable: false),
                   Gigaherz = table.Column<string>(type: "nvarchar(64)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Processor", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Review",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false),
                   Title = table.Column<string>(type: "nvarchar(250)", nullable: false),
                   Text = table.Column<string>(type: "nvarchar(1000)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Review", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Comment",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false),
                   Text = table.Column<string>(type: "nvarchar(1000)", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Comment", x => x.Id);
               });

            migrationBuilder.CreateTable(
               name: "Rating",
               columns: table => new
               {
                   Id = table.Column<int>(type: "int", nullable: false),
                   Stars = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Rating", x => x.Id);
               });
        }
    }
}
