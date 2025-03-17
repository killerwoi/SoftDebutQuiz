using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class _20253172 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "PositionNo",
                table: "Employee",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    PositionNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    PositionName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.PositionNo);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionNo",
                table: "Employee",
                column: "PositionNo");

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Position_PositionNo",
                table: "Employee",
                column: "PositionNo",
                principalTable: "Position",
                principalColumn: "PositionNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Position_PositionNo",
                table: "Employee");

            migrationBuilder.DropTable(
                name: "Position");

            migrationBuilder.DropIndex(
                name: "IX_Employee_PositionNo",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "PositionNo",
                table: "Employee");

            migrationBuilder.AddColumn<string>(
                name: "Position",
                table: "Employee",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
