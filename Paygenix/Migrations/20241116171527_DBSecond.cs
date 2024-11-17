using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Paygenix.Migrations
{
    /// <inheritdoc />
    public partial class DBSecond : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplainceReports_Employee_EmployeeID",
                table: "ComplainceReports");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplainceReports_User_GeneratedBy",
                table: "ComplainceReports");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Employee_UserID",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserID",
                table: "Employee",
                column: "UserID",
                unique: true,
                filter: "[UserID] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainceReports_Employee_EmployeeID",
                table: "ComplainceReports",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainceReports_User_GeneratedBy",
                table: "ComplainceReports",
                column: "GeneratedBy",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComplainceReports_Employee_EmployeeID",
                table: "ComplainceReports");

            migrationBuilder.DropForeignKey(
                name: "FK_ComplainceReports_User_GeneratedBy",
                table: "ComplainceReports");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Employee_UserID",
                table: "Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_UserID",
                table: "Employee",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainceReports_Employee_EmployeeID",
                table: "ComplainceReports",
                column: "EmployeeID",
                principalTable: "Employee",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_ComplainceReports_User_GeneratedBy",
                table: "ComplainceReports",
                column: "GeneratedBy",
                principalTable: "User",
                principalColumn: "UserID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Role_RoleID",
                table: "User",
                column: "RoleID",
                principalTable: "Role",
                principalColumn: "RoleID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
