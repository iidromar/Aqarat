using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HSPA.Migrations
{
    /// <inheritdoc />
    public partial class countryMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Cities",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
              name: "LastUpdatedBy",
              table: "Cities");
        }
    }
}
