using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTracker_App.Migrations
{
    /// <inheritdoc />
    public partial class Remove_Redundant_Issue_Number : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssueNumber",
                table: "Issues");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IssueNumber",
                table: "Issues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
