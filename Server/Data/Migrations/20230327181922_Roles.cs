using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphonePortalVervoortWagner.Server.Data.Migrations
{
    public partial class Roles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processors",
                columns: table => new
                {
                    ProcessorId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Gigaherz = table.Column<string>(type: "TEXT", nullable: true),
                    CoreCount = table.Column<int>(type: "INTEGER", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processors", x => x.ProcessorId);
                });

            migrationBuilder.CreateTable(
                name: "Smartphones",
                columns: table => new
                {
                    SmartphoneId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Category = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Smartphones", x => x.SmartphoneId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneDetails",
                columns: table => new
                {
                    PhoneDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ManufacturorInfo = table.Column<string>(type: "TEXT", nullable: true),
                    DisplaySize = table.Column<double>(type: "REAL", nullable: false),
                    Resolution = table.Column<string>(type: "TEXT", nullable: true),
                    Weight = table.Column<double>(type: "REAL", nullable: false),
                    SmartphoneId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneDetails", x => x.PhoneDetailsId);
                    table.ForeignKey(
                        name: "FK_PhoneDetails_Smartphones_SmartphoneId",
                        column: x => x.SmartphoneId,
                        principalTable: "Smartphones",
                        principalColumn: "SmartphoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reviews",
                columns: table => new
                {
                    ReviewId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    SmartphoneId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                    table.ForeignKey(
                        name: "FK_Reviews_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Reviews_Smartphones_SmartphoneId",
                        column: x => x.SmartphoneId,
                        principalTable: "Smartphones",
                        principalColumn: "SmartphoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PhoneDetailsProcessors",
                columns: table => new
                {
                    PhoneDetailsId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProcessorId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneDetailsProcessors", x => new { x.ProcessorId, x.PhoneDetailsId });
                    table.ForeignKey(
                        name: "FK_PhoneDetailsProcessors_PhoneDetails_PhoneDetailsId",
                        column: x => x.PhoneDetailsId,
                        principalTable: "PhoneDetails",
                        principalColumn: "PhoneDetailsId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PhoneDetailsProcessors_Processors_ProcessorId",
                        column: x => x.ProcessorId,
                        principalTable: "Processors",
                        principalColumn: "ProcessorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    PictureId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    PathToData = table.Column<string>(type: "TEXT", nullable: true),
                    PhoneDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.PictureId);
                    table.ForeignKey(
                        name: "FK_Pictures_PhoneDetails_PhoneDetailsId",
                        column: x => x.PhoneDetailsId,
                        principalTable: "PhoneDetails",
                        principalColumn: "PhoneDetailsId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "INTEGER", nullable: false),
                    Text = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Comments_Reviews_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ratings",
                columns: table => new
                {
                    RatingId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Stars = table.Column<int>(type: "INTEGER", nullable: false),
                    SmartphoneId = table.Column<int>(type: "INTEGER", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: true),
                    ReviewId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ratings", x => x.RatingId);
                    table.ForeignKey(
                        name: "FK_Ratings_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Ratings_Reviews_ReviewId",
                        column: x => x.ReviewId,
                        principalTable: "Reviews",
                        principalColumn: "ReviewId");
                    table.ForeignKey(
                        name: "FK_Ratings_Smartphones_SmartphoneId",
                        column: x => x.SmartphoneId,
                        principalTable: "Smartphones",
                        principalColumn: "SmartphoneId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1dfc233e-b290-4a31-a788-172533af29a4", "60c4fb75-086f-489b-ab07-8ea8e64434cf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96c1e8a0-8362-4ca1-a7e0-869d2d6631aa", "a4815648-fd26-4528-9852-825c60b01e64", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneDetails_SmartphoneId",
                table: "PhoneDetails",
                column: "SmartphoneId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhoneDetailsProcessors_PhoneDetailsId",
                table: "PhoneDetailsProcessors",
                column: "PhoneDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_PhoneDetailsId",
                table: "Pictures",
                column: "PhoneDetailsId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_ReviewId",
                table: "Ratings",
                column: "ReviewId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_SmartphoneId",
                table: "Ratings",
                column: "SmartphoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Ratings_UserId",
                table: "Ratings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_SmartphoneId",
                table: "Reviews",
                column: "SmartphoneId");

            migrationBuilder.CreateIndex(
                name: "IX_Reviews_UserId",
                table: "Reviews",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "PhoneDetailsProcessors");

            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.DropTable(
                name: "Processors");

            migrationBuilder.DropTable(
                name: "PhoneDetails");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Smartphones");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dfc233e-b290-4a31-a788-172533af29a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96c1e8a0-8362-4ca1-a7e0-869d2d6631aa");
        }
    }
}
