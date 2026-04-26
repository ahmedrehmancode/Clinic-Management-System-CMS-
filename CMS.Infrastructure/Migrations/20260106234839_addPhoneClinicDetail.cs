using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Clinic_Management_System_.Migrations
{
    /// <inheritdoc />
    public partial class addPhoneClinicDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "clinicDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Phone",
                table: "clinicDetails");
        }
    }
}
