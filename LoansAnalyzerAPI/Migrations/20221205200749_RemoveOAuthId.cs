using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoansAnalyzerAPI.Migrations
{
    /// <inheritdoc />
    public partial class RemoveOAuthId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OAuthId",
                table: "Clients");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OAuthId",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
