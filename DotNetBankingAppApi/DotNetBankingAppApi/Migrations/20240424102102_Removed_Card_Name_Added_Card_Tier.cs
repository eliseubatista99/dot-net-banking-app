using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DotNetBankingAppApi.Migrations
{
    /// <inheritdoc />
    public partial class Removed_Card_Name_Added_Card_Tier : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardName",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "CardTier",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CardTier",
                table: "Cards");

            migrationBuilder.AddColumn<string>(
                name: "CardName",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
