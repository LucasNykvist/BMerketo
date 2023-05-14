using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bmerketo.Migrations
{
    /// <inheritdoc />
    public partial class UserRegistration_Improved : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProfileImage",
                table: "AspNetUsers",
                newName: "ProfileImageURL");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetName",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "StreetName",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ProfileImageURL",
                table: "AspNetUsers",
                newName: "ProfileImage");
        }
    }
}
