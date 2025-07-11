using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyTracker_App.Migrations
{
    /// <inheritdoc />
    public partial class Message_CreatedBy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedById",
                table: "Messages",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Messages_CreatedById",
                table: "Messages",
                column: "CreatedById");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_AspNetUsers_CreatedById",
                table: "Messages",
                column: "CreatedById",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_AspNetUsers_CreatedById",
                table: "Messages");

            migrationBuilder.DropIndex(
                name: "IX_Messages_CreatedById",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "CreatedById",
                table: "Messages");
        }
    }
}
