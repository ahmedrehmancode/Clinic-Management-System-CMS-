using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Clinic_Management_System_.Migrations
{
    /// <inheritdoc />
    public partial class FixPasswordSpelling : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPassowrd",
                table: "UsersDetails",
                newName: "UserPassword");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserPassword",
                table: "UsersDetails",
                newName: "UserPassowrd");
        }
    }
}
