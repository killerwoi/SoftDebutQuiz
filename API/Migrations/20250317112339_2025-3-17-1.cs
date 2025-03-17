using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class _20253171 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    DepName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepNo);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeBackup",
                columns: table => new
                {
                    EmpNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeBackup", x => x.EmpNum);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmpNum = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EmpName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    HireDate = table.Column<DateOnly>(type: "date", nullable: true),
                    Salary = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Position = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DepNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true),
                    HeadNo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmpNum);
                    table.ForeignKey(
                        name: "FK_Employee_Department_DepNo",
                        column: x => x.DepNo,
                        principalTable: "Department",
                        principalColumn: "DepNo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DepNo",
                table: "Employee",
                column: "DepNo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "EmployeeBackup");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
