using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Clinic_Management_System_.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_clinicDetails_ClinicId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "UsersDetails");

            migrationBuilder.RenameIndex(
                name: "IX_User_ClinicId",
                table: "UsersDetails",
                newName: "IX_UsersDetails_ClinicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UsersDetails",
                table: "UsersDetails",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersDetails_clinicDetails_ClinicId",
                table: "UsersDetails",
                column: "ClinicId",
                principalTable: "clinicDetails",
                principalColumn: "ClinicId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersDetails_clinicDetails_ClinicId",
                table: "UsersDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UsersDetails",
                table: "UsersDetails");

            migrationBuilder.RenameTable(
                name: "UsersDetails",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_UsersDetails_ClinicId",
                table: "User",
                newName: "IX_User_ClinicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_clinicDetails_ClinicId",
                table: "User",
                column: "ClinicId",
                principalTable: "clinicDetails",
                principalColumn: "ClinicId");
        }
    }
}
