using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartphonePortalVervoortWagner.Server.Data.Migrations
{
    public partial class changeProcessor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhoneDetailsProcessors");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1dfc233e-b290-4a31-a788-172533af29a4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "96c1e8a0-8362-4ca1-a7e0-869d2d6631aa");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneDetailsId",
                table: "PhoneDetails",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .OldAnnotation("Sqlite:Autoincrement", true);

            migrationBuilder.AddColumn<int>(
                name: "ProcessorId",
                table: "PhoneDetails",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "922b5b33-037c-4464-8aab-81ff3e713799", "f71e3ef0-bf95-4017-b283-2a5d655091ad", "User", "USER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f2a0de3d-a50d-408e-bb3e-7f66ac0df295", "7fed8674-a5a4-4a44-943a-bdb99cfcf8d9", "Admin", "ADMIN" });

            migrationBuilder.AddForeignKey(
                name: "FK_PhoneDetails_Processors_PhoneDetailsId",
                table: "PhoneDetails",
                column: "PhoneDetailsId",
                principalTable: "Processors",
                principalColumn: "ProcessorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PhoneDetails_Processors_PhoneDetailsId",
                table: "PhoneDetails");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "922b5b33-037c-4464-8aab-81ff3e713799");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f2a0de3d-a50d-408e-bb3e-7f66ac0df295");

            migrationBuilder.DropColumn(
                name: "ProcessorId",
                table: "PhoneDetails");

            migrationBuilder.AlterColumn<int>(
                name: "PhoneDetailsId",
                table: "PhoneDetails",
                type: "INTEGER",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "INTEGER")
                .Annotation("Sqlite:Autoincrement", true);

            migrationBuilder.CreateTable(
                name: "PhoneDetailsProcessors",
                columns: table => new
                {
                    ProcessorId = table.Column<int>(type: "INTEGER", nullable: false),
                    PhoneDetailsId = table.Column<int>(type: "INTEGER", nullable: false)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1dfc233e-b290-4a31-a788-172533af29a4", "60c4fb75-086f-489b-ab07-8ea8e64434cf", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "96c1e8a0-8362-4ca1-a7e0-869d2d6631aa", "a4815648-fd26-4528-9852-825c60b01e64", "User", "USER" });

            migrationBuilder.CreateIndex(
                name: "IX_PhoneDetailsProcessors_PhoneDetailsId",
                table: "PhoneDetailsProcessors",
                column: "PhoneDetailsId");
        }
    }
}
