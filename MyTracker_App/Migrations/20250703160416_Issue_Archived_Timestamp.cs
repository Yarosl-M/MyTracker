using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTracker_App.Migrations
{
    /// <inheritdoc />
    public partial class Issue_Archived_Timestamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "ArchivedAt",
                table: "Issues",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArchivedAt",
                table: "Issues");
        }
    }
}
