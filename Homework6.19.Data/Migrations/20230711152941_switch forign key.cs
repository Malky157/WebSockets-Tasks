using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6._19.Data.Migrations
{
    public partial class switchforignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserIdStarted",
                table: "TaskItems",
                column: "UserIdStarted");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_UserIdStarted",
                table: "TaskItems",
                column: "UserIdStarted",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TaskItems_Users_UserIdStarted",
                table: "TaskItems");

            migrationBuilder.DropIndex(
                name: "IX_TaskItems_UserIdStarted",
                table: "TaskItems");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_UserId",
                table: "TaskItems",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_TaskItems_Users_UserId",
                table: "TaskItems",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
