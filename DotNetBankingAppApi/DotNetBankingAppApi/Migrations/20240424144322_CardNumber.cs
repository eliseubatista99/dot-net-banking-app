using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetBankingAppApi.Migrations
{
    /// <inheritdoc />
    public partial class CardNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardId",
                table: "Cards",
                newName: "CardNumber");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CardNumber",
                table: "Cards",
                newName: "CardId");
        }
    }
}
