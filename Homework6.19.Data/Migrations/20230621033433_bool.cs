using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6._19.Data.Migrations
{
    public partial class @bool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "TaskItems");

            migrationBuilder.AddColumn<bool>(
                name: "IsStarted",
                table: "TaskItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsStarted",
                table: "TaskItems");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "TaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
