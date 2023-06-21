using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6._19.Data.Migrations
{
    public partial class userIdStarted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserIdStarted",
                table: "TaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserIdStarted",
                table: "TaskItems");
        }
    }
}
