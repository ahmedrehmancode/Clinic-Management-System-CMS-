using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CMS_Clinic_Management_System_.Migrations
{
    /// <inheritdoc />
    public partial class clinicdetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clinicDetails",
                columns: table => new
                {
                    ClinicId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClinicName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clinicDetails", x => x.ClinicId);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserPassowrd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClinicId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_User_clinicDetails_ClinicId",
                        column: x => x.ClinicId,
                        principalTable: "clinicDetails",
                        principalColumn: "ClinicId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_ClinicId",
                table: "User",
                column: "ClinicId",
                unique: true,
                filter: "[ClinicId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "clinicDetails");
        }
    }
}
