using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApiLogin.Migrations
{
    public partial class MessageTableM : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Person",
                table: "Message",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Person",
                table: "Message");
        }
    }
}
