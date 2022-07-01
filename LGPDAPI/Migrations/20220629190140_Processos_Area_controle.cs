using Microsoft.EntityFrameworkCore.Migrations;

namespace LGPD.Migrations
{
    public partial class Processos_Area_controle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Area_controle",
                table: "Processos",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area_controle",
                table: "Processos");
        }
    }
}
