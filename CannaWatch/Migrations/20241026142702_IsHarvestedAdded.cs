using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CannaWatch.Migrations
{
    /// <inheritdoc />
    public partial class IsHarvestedAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isHarvested",
                table: "Plants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isHarvested",
                table: "Plants");
        }
    }
}
