using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoansAnalyzerAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddGovernmentIdAndJobDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "GovernmentDocumentId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "JobDetailsId",
                table: "Clients",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OAuthId",
                table: "Clients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "GovernmentDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GovernmentDocument", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobDetails", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Clients_GovernmentDocumentId",
                table: "Clients",
                column: "GovernmentDocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_JobDetailsId",
                table: "Clients",
                column: "JobDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_GovernmentDocument_GovernmentDocumentId",
                table: "Clients",
                column: "GovernmentDocumentId",
                principalTable: "GovernmentDocument",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_JobDetails_JobDetailsId",
                table: "Clients",
                column: "JobDetailsId",
                principalTable: "JobDetails",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_GovernmentDocument_GovernmentDocumentId",
                table: "Clients");

            migrationBuilder.DropForeignKey(
                name: "FK_Clients_JobDetails_JobDetailsId",
                table: "Clients");

            migrationBuilder.DropTable(
                name: "GovernmentDocument");

            migrationBuilder.DropTable(
                name: "JobDetails");

            migrationBuilder.DropIndex(
                name: "IX_Clients_GovernmentDocumentId",
                table: "Clients");

            migrationBuilder.DropIndex(
                name: "IX_Clients_JobDetailsId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "GovernmentDocumentId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "JobDetailsId",
                table: "Clients");

            migrationBuilder.DropColumn(
                name: "OAuthId",
                table: "Clients");
        }
    }
}
