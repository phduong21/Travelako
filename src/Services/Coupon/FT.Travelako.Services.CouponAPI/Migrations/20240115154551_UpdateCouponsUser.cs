using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FT.Travelako.Services.CouponAPI.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCouponsUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsUsed",
                table: "CouponsUser",
                type: "bit",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsUsed",
                table: "CouponsUser");
        }
    }
}
