using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrototipoApi.Migrations
{
    /// <inheritdoc />
    public partial class Inicial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuilidingAmount",
                table: "Requests",
                newName: "BuildingAmount");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BuildingAmount",
                table: "Requests",
                newName: "BuilidingAmount");
        }
    }
}
