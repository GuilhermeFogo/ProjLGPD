using Microsoft.EntityFrameworkCore.Migrations;

namespace LGPD.Migrations
{
    public partial class UserBoll : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativado",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativado",
                table: "Usuarios");
        }
    }
}
