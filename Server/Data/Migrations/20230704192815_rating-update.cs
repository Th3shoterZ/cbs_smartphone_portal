using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SmartphonePortal_Vervoort_Wagner.Server.Migrations
{
    public partial class ratingupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ratings");

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "00d4030d-2fbc-44c2-8bbe-7a89a0c3a1aa", "a5aa17b2-3284-46b2-a4ae-bda7b5852e8c", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37ef961e-e31e-479c-8321-16a29e0ae1a9", "c98becfd-bbc0-421f-80d9-8400ea9ebf8e", "Admin", "ADMIN" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rating_AspNetUsers_UserId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Reviews_ReviewId",
                table: "Rating");

            migrationBuilder.DropForeignKey(
                name: "FK_Rating_Smartphones_SmartphoneId",
                table: "Rating");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Rating",
                table: "Rating");

            migrationBuilder.DropIndex(
                name: "IX_Rating_ReviewId",
                table: "Rating");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "00d4030d-2fbc-44c2-8bbe-7a89a0c3a1aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "37ef961e-e31e-479c-8321-16a29e0ae1a9");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Reviews");

            migrationBuilder.DropColumn(
                name: "ReviewId",
                table: "Rating");

            migrationBuilder.RenameTable(
                name: "Rating",
                newName: "Ratings");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_UserId",
                table: "Ratings",
                newName: "IX_Ratings_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Rating_SmartphoneId",
                table: "Ratings",
                newName: "IX_Ratings_SmartphoneId");

            migrationBuilder.AlterColumn<int>(
                name: "RatingId",
                table: "Ratings",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ratings",
                table: "Ratings",
                column: "RatingId");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "000f9371-f96f-451d-8e63-984ebb7b6916", "25854333-bc13-461b-9818-8d8f9d7b83f3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "cf537e9a-f321-4221-8b43-ac5047e4fb14", "a7960943-e444-4692-81bd-66ddf131de4f", "User", "USER" });

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_AspNetUsers_UserId",
                table: "Ratings",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Reviews_RatingId",
                table: "Ratings",
                column: "RatingId",
                principalTable: "Reviews",
                principalColumn: "ReviewId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ratings_Smartphones_SmartphoneId",
                table: "Ratings",
                column: "SmartphoneId",
                principalTable: "Smartphones",
                principalColumn: "SmartphoneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
