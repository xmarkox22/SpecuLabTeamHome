using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrototipoApi.Migrations
{
    /// <inheritdoc />
    public partial class Ini2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Transactions_ManagementBudgets_ManagementBudgetId",
                table: "Transactions");

            migrationBuilder.DropIndex(
                name: "IX_Transactions_ManagementBudgetId",
                table: "Transactions");

            migrationBuilder.DropColumn(
                name: "ManagementBudgetId",
                table: "Transactions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ManagementBudgetId",
                table: "Transactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Transactions_ManagementBudgetId",
                table: "Transactions",
                column: "ManagementBudgetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Transactions_ManagementBudgets_ManagementBudgetId",
                table: "Transactions",
                column: "ManagementBudgetId",
                principalTable: "ManagementBudgets",
                principalColumn: "ManagementBudgetId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
