using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6._19.Data.Migrations
{
    public partial class removebool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStarted",
                table: "TaskItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsStarted",
                table: "TaskItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
