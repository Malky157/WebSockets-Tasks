using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework6._19.Data.Migrations
{
    public partial class removeforignkeyforuserId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "TaskItems");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "TaskItems",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
